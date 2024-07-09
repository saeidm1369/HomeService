using HomeService.Domain.Core.ServiceAgg.DTOs;

namespace HomeService.EndPoint.WebMVC.Models
{
    public class AdminServiceViewModel
    {
        public IEnumerable<ServiceDTO> Services { get; set; }
        public IEnumerable<ServiceCategoryDTO> ServiceCategories { get; set; }
    }
}
