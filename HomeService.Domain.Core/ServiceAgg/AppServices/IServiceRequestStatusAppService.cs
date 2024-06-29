using HomeService.Domain.Core.ServiceAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.AppServices
{
    public interface IServiceRequestStatusAppService
    {
        Task<ServiceRequestStatusDTO> GetServiceRequestStatusByIdAsync(int id);
        Task<IEnumerable<ServiceRequestStatusDTO>> GetAllServiceRequestStatusesAsync();
        Task<ServiceRequestStatusDTO> CreateServiceRequestStatusAsync(ServiceRequestStatusDTO serviceRequestStatusDto);
        Task<ServiceRequestStatusDTO> UpdateServiceRequestStatusAsync(ServiceRequestStatusDTO serviceRequestStatusDto);
        Task<bool> DeleteServiceRequestStatusAsync(int id);
    }
}
