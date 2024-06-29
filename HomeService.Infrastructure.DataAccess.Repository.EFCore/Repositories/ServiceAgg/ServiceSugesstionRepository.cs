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
    public class ServiceSuggestionRepository : Repository<ServiceSugesstion>, IServiceSugesstionRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceSuggestionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceSugesstion>> GetServiceSugesstionsByServiceRequestIdAsync(int servicerequestId)
        {
            return await _context.ServiceSugesstions.Where(r => r.ServiceRequestId == servicerequestId).ToListAsync();
        }
    }
}
