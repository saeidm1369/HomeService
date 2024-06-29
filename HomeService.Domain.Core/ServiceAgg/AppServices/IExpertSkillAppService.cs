using HomeService.Domain.Core.ServiceAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.AppServices
{
    public interface IExpertSkillAppService
    {
        Task<ExpertSkillDTO> GetExpertSkillByIdAsync(int id);
        Task<IEnumerable<ExpertSkillDTO>> GetAllExpertSkillsAsync();
        Task CreateExpertSkillAsync(ExpertSkillDTO expertSkillDto);
        Task UpdateExpertSkillAsync(ExpertSkillDTO expertSkillDto);
        Task DeleteExpertSkillAsync(int id);
        Task<IEnumerable<ExpertSkillDTO>> GetExpertSkillsByExpertIdAsync(string expertId);
        Task<IEnumerable<ExpertSkillDTO>> GetExpertSkillsBySkillIdAsync(int skillId);
    }
}
