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
    public class ServiceSugesstionService : IServiceSugesstionService
    {
        private readonly IMapper _mapper;
        private readonly IServiceSugesstionRepository _serviceSugesstionRepository;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ServiceSugesstionService> _logger;

        public ServiceSugesstionService(IMapper mapper, IServiceSugesstionRepository serviceSugesstionRepository, IMemoryCache cache, ILogger<ServiceSugesstionService> logger)
        {
            _mapper = mapper;
            _serviceSugesstionRepository = serviceSugesstionRepository;
            _cache = cache;
            _logger = logger;
        }

        public async Task<IEnumerable<ServiceSugesstionDTO>> GetAllServiceSugesstionsAsync()
        {
            if (!_cache.TryGetValue("AllServiceSugesstions", out IEnumerable<ServiceSugesstionDTO> cachedServiceSugesstions))
            {
                var serviceSugesstions = await _serviceSugesstionRepository.GetAllAsync();
                cachedServiceSugesstions = _mapper.Map<IEnumerable<ServiceSugesstionDTO>>(serviceSugesstions);
                _cache.Set("AllServiceSugesstions", cachedServiceSugesstions);
            }

            _logger.LogInformation("Retrieved all ServiceSugesstions from cache");
            return cachedServiceSugesstions;
        }

        public async Task<ServiceSugesstionDTO> GetServiceSugesstionByIdAsync(int id)
        {
            var serviceSugesstion = await _serviceSugesstionRepository.GetByIdAsync(id);
            if (serviceSugesstion == null)
            {
                _logger.LogWarning("ServiceSugesstion not found: {Id}", id);
                throw new KeyNotFoundException("ServiceSugesstion not found.");
            }

            _logger.LogInformation("Retrieved ServiceSugesstion by id: {Id}", id);
            return _mapper.Map<ServiceSugesstionDTO>(serviceSugesstion);
        }

        public async Task AddServiceSugesstionAsync(ServiceSugesstionDTO serviceSugesstionDto)
        {
            var serviceSugesstion = _mapper.Map<ServiceSugesstion>(serviceSugesstionDto);
            await _serviceSugesstionRepository.AddAsync(serviceSugesstion);
            _logger.LogInformation("ServiceSugesstion created: {@ServiceSugesstion}", serviceSugesstion);
            _cache.Remove("AllServiceSugesstions");
        }

        public async Task UpdateServiceSugesstionAsync(ServiceSugesstionDTO serviceSugesstionDto)
        {
            var serviceSugesstion = _mapper.Map<ServiceSugesstion>(serviceSugesstionDto);
            await _serviceSugesstionRepository.UpdateAsync(serviceSugesstion);
            _logger.LogInformation("ServiceSugesstion updated: {@ServiceSugesstion}", serviceSugesstion);
            _cache.Remove("AllServiceSugesstions");
        }

        public async Task DeleteServiceSugesstionAsync(int id)
        {
            await _serviceSugesstionRepository.DeleteAsync(id);
            _logger.LogInformation("ServiceSugesstion deleted: {Id}", id);
            _cache.Remove("AllServiceSugesstions");
        }
    }
}
