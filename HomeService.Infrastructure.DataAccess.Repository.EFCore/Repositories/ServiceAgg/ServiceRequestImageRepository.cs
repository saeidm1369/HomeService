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
    public class ServiceRequestImageRepository : Repository<ServiceRequestImage>, IServiceRequestImageRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceRequestImageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceRequestImage>> GetByServiceRequestIdAsync(int serviceRequestId)
        {
            return await _context.ServiceRequestImages.Where(sri => sri.ServiceRequestId == serviceRequestId).ToListAsync();
        }
    }
}
