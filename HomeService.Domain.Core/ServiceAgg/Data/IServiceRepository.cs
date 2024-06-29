using BaseFramework;
using HomeService.Domain.Core.ServiceAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.Data
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<IEnumerable<Service>> GetAllServicesWithImagesAsync();
        Task<IEnumerable<Service>> GetByServiceCategoryIddAsync(int servicecategoryId);
        Task<Service> GetByNameAsync(string name);
    }
}
