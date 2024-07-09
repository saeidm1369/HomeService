// Controllers/CustomerController.cs
using HomeService.Domain.Core.ServiceAgg.DTOs;
using HomeService.Domain.Core.ServiceAgg.Services;
using HomeService.Domain.Core.UserAgg.DTOs;
using HomeService.Domain.Core.UserAgg.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HomeService.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUserService _userService;
        private readonly IServiceService _serviceService;
        private readonly IServiceRequestService _serviceRequestService;
        private readonly IServiceSugesstionService _serviceSugesstionService;
        private readonly IReviewService _reviewService;
        private readonly ILogger<CustomerController> _logger;
        private readonly IMemoryCache _memoryCache;

        public CustomerController(
            IUserService userService,
            IServiceService serviceService,
            IServiceRequestService serviceRequestService,
            IServiceSugesstionService serviceSugesstionService,
            IReviewService reviewService,
            ILogger<CustomerController> logger,
            IMemoryCache memoryCache)
        {
            _userService = userService;
            _serviceService = serviceService;
            _serviceRequestService = serviceRequestService;
            _serviceSugesstionService = serviceSugesstionService;
            _reviewService = reviewService;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public async Task<IActionResult> Profile()
        {
            var userId = User.Identity.Name; 
            var cacheKey = $"UserProfile_{userId}";

            if (!_memoryCache.TryGetValue(cacheKey, out UserDTO user))
            {
                _logger.LogInformation($"Fetching user profile for userId: {userId}");
                user = await _userService.GetUserByIdAsync(userId);

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));
                _memoryCache.Set(cacheKey, user, cacheOptions);
            }

            return View(user);
        }

        public async Task<IActionResult> Services()
        {
            var cacheKey = "AllServices";

            if (!_memoryCache.TryGetValue(cacheKey, out IEnumerable<ServiceDTO> services))
            {
                _logger.LogInformation("Fetching all services");
                services = await _serviceService.GetAllServicesAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));
                _memoryCache.Set(cacheKey, services, cacheOptions);
            }

            return View(services);
        }

        [HttpGet]
        public IActionResult RequestService(int serviceId)
        {
            ViewBag.ServiceId = serviceId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RequestService(ServiceRequestDTO serviceRequestDto)
        {
            _logger.LogInformation("Adding a new service request");
            await _serviceRequestService.AddServiceRequestAsync(serviceRequestDto);
            return RedirectToAction("Requests");
        }

        public async Task<IActionResult> Requests()
        {
            var cacheKey = "AllServiceRequests";

            if (!_memoryCache.TryGetValue(cacheKey, out IEnumerable<ServiceRequestDTO> requests))
            {
                _logger.LogInformation("Fetching all service requests");
                requests = await _serviceRequestService.GetAllServiceRequestsAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));
                _memoryCache.Set(cacheKey, requests, cacheOptions);
            }

            return View(requests);
        }

        public async Task<IActionResult> Suggestions(int requestId)
        {
            var cacheKey = $"ServiceSuggestions_{requestId}";

            if (!_memoryCache.TryGetValue(cacheKey, out IEnumerable<ServiceSugesstionDTO> suggestions))
            {
                _logger.LogInformation($"Fetching service suggestions for requestId: {requestId}");
                suggestions = await _serviceSugesstionService.GetAllServiceSugesstionsAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));
                _memoryCache.Set(cacheKey, suggestions, cacheOptions);
            }

            return View(suggestions);
        }

        [HttpGet]
        public IActionResult ReviewExpert(int expertId)
        {
            ViewBag.ExpertId = expertId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReviewExpert(ReviewDTO reviewDto)
        {
            _logger.LogInformation($"Adding review for expertId: {reviewDto.Expert}");
            await _reviewService.AddReviewAsync(reviewDto);
            return RedirectToAction("Profile");
        }
    }
}
