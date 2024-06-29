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
    public class ServiceImageRepository : Repository<ServiceImage>, IServiceImageRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceImageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ServiceImage>> GetByServiceIdAsync(int serviceId)
        {
            return await _context.ServiceImages.Where(si => si.ServiceId == serviceId).ToListAsync();
        }
    }
}
