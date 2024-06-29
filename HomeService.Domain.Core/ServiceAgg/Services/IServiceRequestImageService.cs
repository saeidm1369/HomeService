using HomeService.Domain.Core.ServiceAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.Services
{
    public interface IServiceRequestImageService
    {
        Task<ServiceRequestImageDTO> GetServiceRequestImageByIdAsync(int id);
        Task<IEnumerable<ServiceRequestImageDTO>> GetAllServiceRequestImagesAsync();
        Task<ServiceRequestImageDTO> CreateServiceRequestImageAsync(ServiceRequestImageDTO serviceRequestImageDto);
        Task<ServiceRequestImageDTO> UpdateServiceRequestImageAsync(ServiceRequestImageDTO serviceRequestImageDto);
        Task<bool> DeleteServiceRequestImageAsync(int id);
    }
}
