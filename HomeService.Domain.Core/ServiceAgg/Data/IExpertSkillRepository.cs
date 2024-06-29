using BaseFramework;
using HomeService.Domain.Core.ServiceAgg.DTOs;
using HomeService.Domain.Core.ServiceAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.Data
{
    public interface IExpertSkillRepository : IRepository<ExpertSkill>
    {
       Task<IEnumerable<ExpertSkill>> GetExpertSkillsBySkillIdAsync(int skillId);
       Task<IEnumerable<ExpertSkill>> GetExpertSkillsByExpertIdAsync(string expertId);
    }
}
