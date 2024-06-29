using BaseFramework;
using HomeService.Domain.Core.ServiceAgg.Data;
using HomeService.Domain.Core.ServiceAgg.Entities;
using HomeService.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Infrastructure.DataAccess.Repository.EFCore.Repositories.ServiceAgg
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAllServicesWithImagesAsync()
        {
            return await _context.Services
                            .Include(s => s.ServiceImages)
                            .ToListAsync();
        }

        public async Task<Service> GetByNameAsync(string name)
        {
            return await _context.Services.FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task<IEnumerable<Service>> GetByServiceCategoryIddAsync(int servicecategoryId)
        {
            return await _context.Services
                            .Where(s => s.ServiceCategoryId == servicecategoryId)
                            .ToListAsync();
        }
    }
}
