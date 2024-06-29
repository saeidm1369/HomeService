using HomeService.Domain.Core.ServiceAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.Services
{
    public interface IServiceCategoryService
    {
        Task<ServiceCategoryDTO> GetServiceCategoryByIdAsync(int id);
        Task<IEnumerable<ServiceCategoryDTO>> GetAllServiceCategoriesAsync();
        Task<ServiceCategoryDTO> CreateServiceCategoryAsync(ServiceCategoryDTO serviceCategoryDto);
        Task<ServiceCategoryDTO> UpdateServiceCategoryAsync(ServiceCategoryDTO serviceCategoryDto);
        Task<bool> DeleteServiceCategoryAsync(int id);
    }
}
