using HomeService.Domain.Core.ServiceAgg.DTOs;
using HomeService.Domain.Core.ServiceAgg.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeService.EndPoint.WebMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly IServiceService _serviceService;
        private readonly IServiceCategoryService _serviceCategoryService;
        private readonly IReviewService _reviewService;
        private readonly IServiceRequestStatusService _statusService;

        public AdminController(IServiceRequestService serviceRequestService, IServiceService serviceService, IReviewService reviewService, IServiceRequestStatusService statusService)
        {
            _serviceRequestService = serviceRequestService;
            _serviceService = serviceService;
            _reviewService = reviewService;
            _statusService = statusService;
        }

        // مدیریت و امکان تغییر وضعیت درخواست‌ها
        public async Task<IActionResult> ManageRequests()
        {
            var requests = await _serviceRequestService.GetAllServiceRequestsAsync();
            return View(requests);
        }

        public async Task<IActionResult> ChangeRequestStatus(int id, int newStatusId)
        {
            await _statusService.ChangeRequestStatusAsync(id, newStatusId);
            return RedirectToAction(nameof(ManageRequests));
        }

        // مدیریت خدمات و دسته‌بندی‌ها
        public async Task<IActionResult> ManageServices()
        {
            var services = await _serviceService.GetAllServicesAsync();
            var categories = await _serviceCategoryService.GetAllServiceCategoriesAsync();
            var model = new AdminServiceViewModel { Services = services, ServiceCategories = categories };
            return View(model);
        }

        // مدیریت کامنت‌ها و امتیازات
        public async Task<IActionResult> ManageComments()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
            return View(reviews);
        }

        public async Task<IActionResult> DeleteComment(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            await _reviewService.DeleteReviewAsync(id);

            return RedirectToAction(nameof(ManageComments));
        }
    }

    public class AdminServiceViewModel
    {
        public IEnumerable<ServiceDTO> Services { get; set; }
        public IEnumerable<ServiceCategoryDTO> ServiceCategories { get; set; }
    }
}
