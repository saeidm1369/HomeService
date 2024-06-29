using HomeService.Domain.Core.ServiceAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.AppServices
{
    public interface IServiceAppService
    {
        Task<IEnumerable<ServiceDTO>> GetAllServicesAsync();
        Task<ServiceDTO> GetServiceByIdAsync(int id);
        Task AddServiceAsync(ServiceDTO serviceDto);
        Task UpdateServiceAsync(ServiceDTO serviceDto);
        Task DeleteServiceAsync(int id);
    }
}
