using HomeService.Domain.Core.ServiceAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.Services
{
    public interface IServiceImageService
    {
        Task<ServiceImageDTO> GetServiceImageByIdAsync(int id);
        Task<IEnumerable<ServiceImageDTO>> GetAllServiceImagesAsync();
        Task<ServiceImageDTO> CreateServiceImageAsync(ServiceImageDTO serviceImageDto);
        Task<ServiceImageDTO> UpdateServiceImageAsync(ServiceImageDTO serviceImageDto);
        Task<bool> DeleteServiceImageAsync(int id);
    }
}
