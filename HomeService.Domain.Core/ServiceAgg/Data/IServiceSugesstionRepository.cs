using BaseFramework;
using HomeService.Domain.Core.ServiceAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.Data
{
    public interface IServiceSugesstionRepository : IRepository<ServiceSugesstion>
    {
        Task<IEnumerable<ServiceSugesstion>> GetServiceSugesstionsByServiceRequestIdAsync(int servicerequestId);

    }
}
