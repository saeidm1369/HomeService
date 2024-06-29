using AutoMapper;
using HomeService.Domain.Core.ServiceAgg.Data;
using HomeService.Domain.Core.ServiceAgg.DTOs;
using HomeService.Domain.Core.ServiceAgg.Entities;
using HomeService.Domain.Core.ServiceAgg.Services;
using HomeService.Domain.Core.UserAgg.Data;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Services.ServiceAgg
{
    public class ExpertSkillService : IExpertSkillService
    {
        private readonly IExpertSkillRepository _expertSkillRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ExpertSkillService> _logger;

        public ExpertSkillService(
            IExpertSkillRepository expertSkillRepository,
            IUserRepository userRepository,
            ISkillRepository skillRepository,
            IMapper mapper,
            IMemoryCache cache,
            ILogger<ExpertSkillService> logger)
        {
            _expertSkillRepository = expertSkillRepository;
            _userRepository = userRepository;
            _skillRepository = skillRepository;
            _mapper = mapper;
            _cache = cache;
            _logger = logger;
        }

        public async Task CreateExpertSkillAsync(ExpertSkillDTO expertSkillDto)
        {
            var expertSkill = _mapper.Map<ExpertSkill>(expertSkillDto);
            await _expertSkillRepository.AddAsync(expertSkill);
            _logger.LogInformation("ExpertSkill created: {@ExpertSkill}", expertSkill);
            _cache.Remove("AllExpertSkills");
        }

        public async Task DeleteExpertSkillAsync(int id)
        {
            await _expertSkillRepository.DeleteAsync(id);
            _logger.LogInformation("ExpertSkill deleted: {Id}", id);
            _cache.Remove("AllExpertSkills");
        }

        public async Task<IEnumerable<ExpertSkillDTO>> GetAllExpertSkillsAsync()
        {
            if (!_cache.TryGetValue("AllExpertSkills", out IEnumerable<ExpertSkillDTO> cachedExpertSkills))
            {
                var expertSkills = await _expertSkillRepository.GetAllAsync();
                cachedExpertSkills = _mapper.Map<IEnumerable<ExpertSkillDTO>>(expertSkills);
                _cache.Set("AllExpertSkills", cachedExpertSkills);
            }

            _logger.LogInformation("Retrieved all ExpertSkills from cache");
            return cachedExpertSkills;
        }

        public async Task<ExpertSkillDTO> GetExpertSkillByIdAsync(int id)
        {
            var expertSkill = await _expertSkillRepository.GetByIdAsync(id);
            if (expertSkill == null)
            {
                _logger.LogWarning("ExpertSkill not found: {Id}", id);
                throw new KeyNotFoundException("ExpertSkill not found.");
            }

            _logger.LogInformation("Retrieved ExpertSkill by id: {Id}", id);
            return _mapper.Map<ExpertSkillDTO>(expertSkill);
        }

        public async Task<IEnumerable<ExpertSkillDTO>> GetExpertSkillsByExpertIdAsync(string expertId)
        {
            var expertSkills = await _expertSkillRepository.GetExpertSkillsByExpertIdAsync(expertId);
            _logger.LogInformation("Retrieved ExpertSkills by expert id: {ExpertId}", expertId);
            return _mapper.Map<IEnumerable<ExpertSkillDTO>>(expertSkills);
        }

        public async Task<IEnumerable<ExpertSkillDTO>> GetExpertSkillsBySkillIdAsync(int skillId)
        {
            var expertSkills = await _expertSkillRepository.GetExpertSkillsBySkillIdAsync(skillId);
            _logger.LogInformation("Retrieved ExpertSkills by skill id: {SkillId}", skillId);
            return _mapper.Map<IEnumerable<ExpertSkillDTO>>(expertSkills);
        }

        public async Task UpdateExpertSkillAsync(ExpertSkillDTO expertSkillDto)
        {
            var expertSkill = _mapper.Map<ExpertSkill>(expertSkillDto);
            await _expertSkillRepository.UpdateAsync(expertSkill);
            _logger.LogInformation("ExpertSkill updated: {@ExpertSkill}", expertSkill);
            _cache.Remove("AllExpertSkills");
        }


    }
}


