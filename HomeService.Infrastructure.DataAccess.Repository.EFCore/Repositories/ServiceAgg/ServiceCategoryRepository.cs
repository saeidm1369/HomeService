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
    public class ServiceCategoryRepository : Repository<ServiceCategory>, IServiceCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceCategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ServiceCategory> GetByNameAsync(string name)
        {
            return await _context.ServiceCategories.FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}
