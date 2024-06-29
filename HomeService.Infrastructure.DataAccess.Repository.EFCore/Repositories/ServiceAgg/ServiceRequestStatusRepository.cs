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
    public class ServiceRequestStatusRepository : Repository<ServiceRequestStatus>, IServiceRequestStatusRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceRequestStatusRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ServiceRequestStatus> GetByNameAsync(string name)
        {
            return await _context.ServiceRequestStatuses.FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}
