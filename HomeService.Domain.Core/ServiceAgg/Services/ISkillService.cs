using HomeService.Domain.Core.ServiceAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.Services
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillDTO>> GetAllSkillsAsync();
        Task<SkillDTO> GetSkillByIdAsync(int id);
        Task AddSkillAsync(SkillDTO skillDto);
        Task UpdateSkillAsync(SkillDTO skillDto);
        Task DeleteSkillAsync(int id);
    }
}
