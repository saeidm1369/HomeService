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
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        private readonly ApplicationDbContext _context;
        public SkillRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Skill> GetByNameAsync(string name)
        {
            return await _context.Skills.FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}
