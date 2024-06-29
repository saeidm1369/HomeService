using AutoMapper;
using HomeService.Domain.Core.ServiceAgg.Data;
using HomeService.Domain.Core.ServiceAgg.DTOs;
using HomeService.Domain.Core.ServiceAgg.Entities;
using HomeService.Domain.Core.ServiceAgg.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Services.ServiceAgg
{
    public class SkillService : ISkillService
    {
        private readonly IMapper _mapper;
        private readonly ISkillRepository _skillRepository;
        private readonly IMemoryCache _cache;
        private readonly ILogger<SkillService> _logger;

        public SkillService(IMapper mapper, ISkillRepository skillRepository, IMemoryCache cache, ILogger<SkillService> logger)
        {
            _mapper = mapper;
            _skillRepository = skillRepository;
            _cache = cache;
            _logger = logger;
        }

        public async Task<IEnumerable<SkillDTO>> GetAllSkillsAsync()
        {
            if (!_cache.TryGetValue("AllSkills", out IEnumerable<SkillDTO> cachedSkills))
            {
                var skills = await _skillRepository.GetAllAsync();
                cachedSkills = _mapper.Map<IEnumerable<SkillDTO>>(skills);
                _cache.Set("AllSkills", cachedSkills);
            }

            _logger.LogInformation("Retrieved all Skills from cache");
            return cachedSkills;
        }

        public async Task<SkillDTO> GetSkillByIdAsync(int id)
        {
            var skill = await _skillRepository.GetByIdAsync(id);
            if (skill == null)
            {
                _logger.LogWarning("Skill not found: {Id}", id);
                throw new KeyNotFoundException("Skill not found.");
            }

            _logger.LogInformation("Retrieved Skill by id: {Id}", id);
            return _mapper.Map<SkillDTO>(skill);
        }

        public async Task AddSkillAsync(SkillDTO skillDto)
        {
            var skill = _mapper.Map<Skill>(skillDto);
            await _skillRepository.AddAsync(skill);
            _logger.LogInformation("Skill created: {@Skill}", skill);
            _cache.Remove("AllSkills");
        }

        public async Task UpdateSkillAsync(SkillDTO skillDto)
        {
            var skill = _mapper.Map<Skill>(skillDto);
            await _skillRepository.UpdateAsync(skill);
            _logger.LogInformation("Skill updated: {@Skill}", skill);
            _cache.Remove("AllSkills");
        }

        public async Task DeleteSkillAsync(int id)
        {
            await _skillRepository.DeleteAsync(id);
            _logger.LogInformation("Skill deleted: {Id}", id);
            _cache.Remove("AllSkills");
        }
    }
}
