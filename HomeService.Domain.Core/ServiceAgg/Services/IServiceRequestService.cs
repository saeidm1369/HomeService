using HomeService.Domain.Core.ServiceAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.Services
{
    public interface IServiceRequestService
    {
        Task<IEnumerable<ServiceRequestDTO>> GetAllServiceRequestsAsync();
        Task<ServiceRequestDTO> GetServiceRequestByIdAsync(int id);
        Task AddServiceRequestAsync(ServiceRequestDTO serviceRequestDto);
        Task UpdateServiceRequestAsync(ServiceRequestDTO serviceRequestDto);
        Task DeleteServiceRequestAsync(int id);
    }
}
