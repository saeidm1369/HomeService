using HomeService.Domain.Core.UserAgg.DTOs;
using HomeService.Domain.Core.UserAgg.Entities;
using HomeService.Domain.Core.UserAgg.Services;
using HomeService.EndPoint.WebMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace HomeService.EndPoint.WebMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMemoryCache _cache;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            IUserService userService,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMemoryCache cache,
            ILogger<AuthController> logger)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _cache = cache;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                _logger.LogWarning("Email or Password is null or empty.");
                ModelState.AddModelError(string.Empty, "Email and Password are required.");
                return View(model);
            }

            // Validate if the user exists
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                _logger.LogWarning($"No user found with email {model.Email}");
                ModelState.AddModelError(string.Empty, "نام کاربری یا رمز عبور اشتباه است.");
                return View(model);
            }

            var cacheKey = $"Login_{model.Email}";
            Microsoft.AspNetCore.Identity.SignInResult result = null;

            if (!_cache.TryGetValue(cacheKey, out result))
            {
                try
                {
                    result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);
                }
                catch (SqlNullValueException ex)
                {
                    _logger.LogError(ex, "SqlNullValueException occurred during sign in.");
                    ModelState.AddModelError(string.Empty, "An error occurred while signing in. Please try again later.");
                    return View(model);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while signing in.");
                    ModelState.AddModelError(string.Empty, "An error occurred while signing in. Please try again later.");
                    return View(model);
                }

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2)
                };
                _cache.Set(cacheKey, result, cacheEntryOptions);
            }

            if (result.Succeeded)
            {
                _logger.LogInformation($"کاربر {model.Email} با موفقیت وارد شد.");
                TempData["SuccessMessage"] = "با موفقیت وارد شدید.";
                return RedirectToAction("Index", "Home");
            }

            _logger.LogWarning($"تلاش ناموفق برای ورود توسط کاربر {model.Email}.");
            ModelState.AddModelError(string.Empty, "نام کاربری یا رمز عبور اشتباه است.");
            return View(model);
        }





        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User
            {
                UserName = model.Email,
                Email = model.Email
            };

            var cacheKey = $"Register_{model.Email}";
            if (!_cache.TryGetValue(cacheKey, out IdentityResult result))
            {
                try
                {
                    result = await _userManager.CreateAsync(user, model.Password);

                    var cacheEntryOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                        SlidingExpiration = TimeSpan.FromMinutes(2)
                    };
                    _cache.Set(cacheKey, result, cacheEntryOptions);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while registering user.");
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the entity changes. See the inner exception for details.");
                    return View(model);
                }
            }

            if (result.Succeeded)
            {
                // Assign role based on selected user type
                if (model.IsExpert)
                {
                    await _userManager.AddToRoleAsync(user, "Expert");
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                }

                _logger.LogInformation($"کاربر {model.Email} با موفقیت ثبت نام کرد.");
                TempData["SuccessMessage"] = "ثبت نام با موفقیت انجام شد.";
                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            _logger.LogWarning($"تلاش ناموفق برای ثبت نام توسط کاربر {model.Email}. خطاها: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("کاربر با موفقیت خارج شد.");
            return RedirectToAction("Index", "Home");
        }
    }
}