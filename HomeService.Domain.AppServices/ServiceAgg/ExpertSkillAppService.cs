using AutoMapper;
using HomeService.Domain.Core.ServiceAgg.AppServices;
using HomeService.Domain.Core.ServiceAgg.Data;
using HomeService.Domain.Core.ServiceAgg.DTOs;
using HomeService.Domain.Core.ServiceAgg.Entities;
using HomeService.Domain.Core.UserAgg.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.AppServices.ServiceAgg
{
    public class ExpertSkillAppService(
   IExpertSkillRepository expertSkillRepository,
   IUserRepository userRepository,
   ISkillRepository skillRepository,
   IMapper mapper) : IExpertSkillAppService
    {
        private readonly IExpertSkillRepository _expertSkillRepository = expertSkillRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ISkillRepository _skillRepository = skillRepository;
        private readonly IMapper _mapper = mapper;

        public async Task CreateExpertSkillAsync(ExpertSkillDTO expertSkillDto)
        {
            var expertSkill = _mapper.Map<ExpertSkill>(expertSkillDto);
            await _expertSkillRepository.AddAsync(expertSkill);
        }

        public async Task DeleteExpertSkillAsync(int id)
        {
            await _expertSkillRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ExpertSkillDTO>> GetAllExpertSkillsAsync()
        {
            var expertSkills = await _expertSkillRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ExpertSkillDTO>>(expertSkills);
        }

        public async Task<ExpertSkillDTO> GetExpertSkillByIdAsync(int id)
        {
            var expertSkill = await _expertSkillRepository.GetByIdAsync(id);
            if (expertSkill == null)
            {
                throw new KeyNotFoundException("ExpertSkill not found.");
            }

            return _mapper.Map<ExpertSkillDTO>(expertSkill);
        }

        public async Task<IEnumerable<ExpertSkillDTO>> GetExpertSkillsByExpertIdAsync(string expertId)
        {
            var expertSkills = await _expertSkillRepository.GetExpertSkillsByExpertIdAsync(expertId);
            return _mapper.Map<IEnumerable<ExpertSkillDTO>>(expertSkills);
        }

        public async Task<IEnumerable<ExpertSkillDTO>> GetExpertSkillsBySkillIdAsync(int skillId)
        {
            var expertSkills = await _expertSkillRepository.GetExpertSkillsBySkillIdAsync(skillId);
            return _mapper.Map<IEnumerable<ExpertSkillDTO>>(expertSkills);
        }

        public async Task UpdateExpertSkillAsync(ExpertSkillDTO expertSkillDto)
        {
            var expertSkill = _mapper.Map<ExpertSkill>(expertSkillDto);
            await _expertSkillRepository.UpdateAsync(expertSkill);
        }
    
    }
}
