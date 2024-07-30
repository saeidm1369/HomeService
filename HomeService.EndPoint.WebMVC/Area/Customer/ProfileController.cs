using HomeService.Domain.Core.UserAgg.Entities;
using HomeService.EndPoint.WebMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.WebMVC.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;

        public ProfileController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var model = new ProfileViewModel
            {
                Email = user.Email,
                FullName = user.FullName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                NationalCode = user.NationalCode
            };

            return View(model);
        }
    }
}
