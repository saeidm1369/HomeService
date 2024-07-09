using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;
using HomeService.Domain.Core.ServiceAgg.Services;
using HomeService.Domain.Core.UserAgg.Services;
using HomeService.Domain.Core.ServiceAgg.DTOs;
using HomeService.Domain.Core.UserAgg.DTOs;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace HomeService.Web.Controllers
{
    public class ExpertController : Controller
    {
        private readonly ILogger<ExpertController> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly IUserService _userService;
        private readonly IServiceRequestService _serviceRequestService;
        private readonly IServiceSugesstionService _serviceSugesstionService;
        private readonly IExpertSkillService _expertSkillService;

        public ExpertController(
            ILogger<ExpertController> logger,
            IMemoryCache memoryCache,
            IUserService userService,
            IServiceRequestService serviceRequestService,
            IServiceSugesstionService serviceSugesstionService,
            IExpertSkillService expertSkillService)
        {
            _logger = logger;
            _memoryCache = memoryCache;
            _userService = userService;
            _serviceRequestService = serviceRequestService;
            _serviceSugesstionService = serviceSugesstionService;
            _expertSkillService = expertSkillService;
        }

        public async Task<IActionResult> Profile()
        {
            var userId = User.Identity.Name; // فرض بر اینکه شناسه کاربر در نام کاربری ذخیره شده است
            var user = await _userService.GetUserByIdAsync(userId);
            return View(user);
        }

        public async Task<IActionResult> EditProfile()
        {
            var userId = User.Identity.Name;
            var user = await _userService.GetUserByIdAsync(userId);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserDTO userDto)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateUserAsync(userDto.Id);
                return RedirectToAction(nameof(Profile));
            }
            return View(userDto);
        }

        public async Task<IActionResult> Requests()
        {
            var userId = User.Identity.Name;
            var skills = await _expertSkillService.GetExpertSkillsByExpertIdAsync(userId);
            var requests = await _serviceRequestService.GetAllServiceRequestsAsync();
            var filteredRequests = requests.Where(r => skills.Any(s => s.SkillId == r.Id));
            return View(filteredRequests);
        }

        public async Task<IActionResult> SendProposal(int requestId)
        {
            var userId = User.Identity.Name;
            var user = await _userService.GetUserByIdAsync(userId);
            var request = await _serviceRequestService.GetServiceRequestByIdAsync(requestId);

            var proposal = new ServiceSugesstionDTO
            {
                ServiceRequest = request,
                Expert = user,
                ServiceSugesstionPrice = 0, // مقدار پیش‌فرض برای قیمت
                ServiceSugesstionDescription = "", // مقدار پیش‌فرض برای توضیحات
                ServiceSugesstionDate = DateTime.Now
            };
            await _serviceSugesstionService.AddServiceSugesstionAsync(proposal);
            return RedirectToAction(nameof(Requests));
        }

        public async Task<IActionResult> CompleteRequest(int requestId)
        {
            var request = await _serviceRequestService.GetServiceRequestByIdAsync(requestId);
            request.ServiceRequestStatus = new ServiceRequestStatusDTO { Id = 4 }; // مقدار صحیح وضعیت "تکمیل شده"
            await _serviceRequestService.UpdateServiceRequestAsync(request);
            return RedirectToAction(nameof(Requests));
        }
    }
}
