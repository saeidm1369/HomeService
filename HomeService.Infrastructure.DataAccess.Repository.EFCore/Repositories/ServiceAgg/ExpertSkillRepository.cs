using BaseFramework;
using HomeService.Domain.Core.ServiceAgg.Data;
using HomeService.Domain.Core.ServiceAgg.DTOs;
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
    public class ExpertSkillRepository : Repository<ExpertSkill>, IExpertSkillRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpertSkillRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<ExpertSkill>> GetExpertSkillsBySkillIdAsync(int skillId)
        {
            return await _context.ExpertSkills.Where(es => es.SkillId == skillId).ToListAsync();
        }
        

        public async Task<IEnumerable<ExpertSkill>> GetExpertSkillsByExpertIdAsync(string expertId)
        {
            return await _context.ExpertSkills.Where(es => es.ExpertId == expertId).ToListAsync();
        }
    }
}

