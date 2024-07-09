using HomeService.Domain.Core.ServiceAgg.DTOs;
using HomeService.Domain.Core.ServiceAgg.Services;
using HomeService.EndPoint.WebMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
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
        private readonly IMemoryCache _cache;
        private readonly ILogger<AdminController> _logger;

        public AdminController(
            IServiceRequestService serviceRequestService,
            IServiceService serviceService,
            IServiceCategoryService serviceCategoryService,
            IReviewService reviewService,
            IServiceRequestStatusService statusService,
            IMemoryCache cache,
            ILogger<AdminController> logger)
        {
            _serviceRequestService = serviceRequestService;
            _serviceService = serviceService;
            _serviceCategoryService = serviceCategoryService;
            _reviewService = reviewService;
            _statusService = statusService;
            _cache = cache;
            _logger = logger;
        }

        public async Task<IActionResult> ManageRequests()
        {
            _logger.LogInformation("ManageRequests action called.");

            const string cacheKey = "AllServiceRequests";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<ServiceRequestDTO> requests))
            {
                requests = await _serviceRequestService.GetAllServiceRequestsAsync();
                _cache.Set(cacheKey, requests);
                _logger.LogInformation("Service requests retrieved from database and cached.");
            }
            else
            {
                _logger.LogInformation("Service requests retrieved from cache.");
            }

            return View(requests);
        }

        public async Task<IActionResult> ChangeRequestStatus(int id, int newStatusId)
        {
            _logger.LogInformation("ChangeRequestStatus action called with id: {id}, newStatusId: {newStatusId}", id, newStatusId);
            await _statusService.ChangeRequestStatusAsync(id, newStatusId);
            _cache.Remove("AllServiceRequests");
            _logger.LogInformation("Service request status changed and cache invalidated.");
            return RedirectToAction(nameof(ManageRequests));
        }

        public async Task<IActionResult> ManageServices()
        {
            _logger.LogInformation("ManageServices action called.");

            const string servicesCacheKey = "AllServices";
            const string categoriesCacheKey = "AllServiceCategories";

            if (!_cache.TryGetValue(servicesCacheKey, out IEnumerable<ServiceDTO> services))
            {
                services = await _serviceService.GetAllServicesAsync();
                _cache.Set(servicesCacheKey, services);
                _logger.LogInformation("Services retrieved from database and cached.");
            }
            else
            {
                _logger.LogInformation("Services retrieved from cache.");
            }

            if (!_cache.TryGetValue(categoriesCacheKey, out IEnumerable<ServiceCategoryDTO> categories))
            {
                categories = await _serviceCategoryService.GetAllServiceCategoriesAsync();
                _cache.Set(categoriesCacheKey, categories);
                _logger.LogInformation("Service categories retrieved from database and cached.");
            }
            else
            {
                _logger.LogInformation("Service categories retrieved from cache.");
            }

            var model = new AdminServiceViewModel { Services = services, ServiceCategories = categories };
            return View(model);
        }

        public async Task<IActionResult> AddService()
        {
            _logger.LogInformation("AddService action called.");

            const string categoriesCacheKey = "AllServiceCategories";
            if (!_cache.TryGetValue(categoriesCacheKey, out IEnumerable<ServiceCategoryDTO> categories))
            {
                categories = await _serviceCategoryService.GetAllServiceCategoriesAsync();
                _cache.Set(categoriesCacheKey, categories);
                _logger.LogInformation("Service categories retrieved from database and cached.");
            }
            else
            {
                _logger.LogInformation("Service categories retrieved from cache.");
            }

            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddService(ServiceDTO serviceDto)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("AddService action called with valid model.");
                await _serviceService.AddServiceAsync(serviceDto);
                _cache.Remove("AllServices");
                _logger.LogInformation("Service added and cache invalidated.");
                return RedirectToAction(nameof(ManageServices));
            }

            _logger.LogWarning("AddService action called with invalid model.");

            const string categoriesCacheKey = "AllServiceCategories";
            if (!_cache.TryGetValue(categoriesCacheKey, out IEnumerable<ServiceCategoryDTO> categories))
            {
                categories = await _serviceCategoryService.GetAllServiceCategoriesAsync();
                _cache.Set(categoriesCacheKey, categories);
            }
            ViewBag.Categories = categories;

            return View(serviceDto);
        }

        public async Task<IActionResult> EditService(int id)
        {
            _logger.LogInformation("EditService action called with id: {id}", id);

            var service = await _serviceService.GetServiceByIdAsync(id);
            if (service == null)
            {
                _logger.LogWarning("Service not found with id: {id}", id);
                return NotFound();
            }

            const string categoriesCacheKey = "AllServiceCategories";
            if (!_cache.TryGetValue(categoriesCacheKey, out IEnumerable<ServiceCategoryDTO> categories))
            {
                categories = await _serviceCategoryService.GetAllServiceCategoriesAsync();
                _cache.Set(categoriesCacheKey, categories);
            }
            ViewBag.Categories = categories;

            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> EditService(ServiceDTO serviceDto)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("EditService action called with valid model.");
                await _serviceService.UpdateServiceAsync(serviceDto);
                _cache.Remove("AllServices");
                _logger.LogInformation("Service updated and cache invalidated.");
                return RedirectToAction(nameof(ManageServices));
            }

            _logger.LogWarning("EditService action called with invalid model.");

            const string categoriesCacheKey = "AllServiceCategories";
            if (!_cache.TryGetValue(categoriesCacheKey, out IEnumerable<ServiceCategoryDTO> categories))
            {
                categories = await _serviceCategoryService.GetAllServiceCategoriesAsync();
                _cache.Set(categoriesCacheKey, categories);
            }
            ViewBag.Categories = categories;

            return View(serviceDto);
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            _logger.LogInformation("DeleteService action called with id: {id}", id);

            var service = await _serviceService.GetServiceByIdAsync(id);
            if (service == null)
            {
                _logger.LogWarning("Service not found with id: {id}", id);
                return NotFound();
            }

            return View(service);
        }

        [HttpPost, ActionName("DeleteService")]
        public async Task<IActionResult> DeleteServiceConfirmed(int id)
        {
            _logger.LogInformation("DeleteServiceConfirmed action called with id: {id}", id);

            await _serviceService.DeleteServiceAsync(id);
            _cache.Remove("AllServices");
            _logger.LogInformation("Service deleted and cache invalidated.");

            return RedirectToAction(nameof(ManageServices));
        }

        public async Task<IActionResult> ManageComments()
        {
            _logger.LogInformation("ManageComments action called.");

            const string reviewsCacheKey = "AllReviews";
            if (!_cache.TryGetValue(reviewsCacheKey, out IEnumerable<ReviewDTO> reviews))
            {
                reviews = await _reviewService.GetAllReviewsAsync();
                _cache.Set(reviewsCacheKey, reviews);
                _logger.LogInformation("Reviews retrieved from database and cached.");
            }
            else
            {
                _logger.LogInformation("Reviews retrieved from cache.");
            }

            return View(reviews);
        }

        public async Task<IActionResult> DeleteComment(int id)
        {
            _logger.LogInformation("DeleteComment action called with id: {id}", id);

            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
            {
                _logger.LogWarning("Review not found with id: {id}", id);
                return NotFound();
            }

            return View(review);
        }

        [HttpPost, ActionName("DeleteComment")]
        public async Task<IActionResult> DeleteCommentConfirmed(int id)
        {
            _logger.LogInformation("DeleteCommentConfirmed action called with id: {id}", id);

            await _reviewService.DeleteReviewAsync(id);
            _cache.Remove("AllReviews");
            _logger.LogInformation("Review deleted and cache invalidated.");

            return RedirectToAction(nameof(ManageComments));
        }

        public async Task<IActionResult> ApproveComment(int id)
        {
            _logger.LogInformation("ApproveComment action called with id: {id}", id);

            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
            {
                _logger.LogWarning("Review not found with id: {id}", id);
                return NotFound();
            }

            review.IsApproved = true;
            await _reviewService.UpdateReviewAsync(review);
            _cache.Remove("AllReviews");
            _logger.LogInformation("Review approved and cache invalidated.");

            return RedirectToAction(nameof(ManageComments));
        }
    }
}
