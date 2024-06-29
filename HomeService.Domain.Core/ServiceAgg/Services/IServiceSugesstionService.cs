using HomeService.Domain.Core.ServiceAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.Services
{
    public interface IServiceSugesstionService
    {
        Task<IEnumerable<ServiceSugesstionDTO>> GetAllServiceSugesstionsAsync();
        Task<ServiceSugesstionDTO> GetServiceSugesstionByIdAsync(int id);
        Task AddServiceSugesstionAsync(ServiceSugesstionDTO ServiceSugesstionDTO);
        Task UpdateServiceSugesstionAsync(ServiceSugesstionDTO ServiceSugesstionDTO);
        Task DeleteServiceSugesstionAsync(int id);
    }
}
