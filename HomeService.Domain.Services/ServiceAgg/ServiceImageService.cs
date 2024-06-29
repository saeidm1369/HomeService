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
    public class ServiceImageService : IServiceImageService
    {
        private readonly IServiceImageRepository _serviceImageRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ServiceImageService> _logger;

        public ServiceImageService(IServiceImageRepository serviceImageRepository, IMapper mapper, IMemoryCache cache, ILogger<ServiceImageService> logger)
        {
            _serviceImageRepository = serviceImageRepository;
            _mapper = mapper;
            _cache = cache;
            _logger = logger;
        }

        public async Task<ServiceImageDTO> GetServiceImageByIdAsync(int id)
        {
            var serviceImage = await _serviceImageRepository.GetByIdAsync(id);
            if (serviceImage == null)
            {
                _logger.LogWarning("ServiceImage not found: {Id}", id);
                throw new KeyNotFoundException("ServiceImage not found.");
            }

            _logger.LogInformation("Retrieved ServiceImage by id: {Id}", id);
            return _mapper.Map<ServiceImageDTO>(serviceImage);
        }

        public async Task<IEnumerable<ServiceImageDTO>> GetAllServiceImagesAsync()
        {
            if (!_cache.TryGetValue("AllServiceImages", out IEnumerable<ServiceImageDTO> cachedServiceImages))
            {
                var serviceImages = await _serviceImageRepository.GetAllAsync();
                cachedServiceImages = _mapper.Map<IEnumerable<ServiceImageDTO>>(serviceImages);
                _cache.Set("AllServiceImages", cachedServiceImages);
            }

            _logger.LogInformation("Retrieved all ServiceImages from cache");
            return cachedServiceImages;
        }

        public async Task<ServiceImageDTO> CreateServiceImageAsync(ServiceImageDTO serviceImageDto)
        {
            var serviceImage = _mapper.Map<ServiceImage>(serviceImageDto);
            await _serviceImageRepository.AddAsync(serviceImage);
            _logger.LogInformation("ServiceImage created: {@ServiceImage}", serviceImage);
            _cache.Remove("AllServiceImages");
            return _mapper.Map<ServiceImageDTO>(serviceImage);
        }

        public async Task<ServiceImageDTO> UpdateServiceImageAsync(ServiceImageDTO serviceImageDto)
        {
            var serviceImage = _mapper.Map<ServiceImage>(serviceImageDto);
            await _serviceImageRepository.UpdateAsync(serviceImage);
            _logger.LogInformation("ServiceImage updated: {@ServiceImage}", serviceImage);
            _cache.Remove("AllServiceImages");
            return _mapper.Map<ServiceImageDTO>(serviceImage);
        }

        public async Task<bool> DeleteServiceImageAsync(int id)
        {
            var result = await _serviceImageRepository.DeleteAsync(id);
            _logger.LogInformation("ServiceImage deleted: {Id}", id);
            _cache.Remove("AllServiceImages");
            return result;
        }
    }
}
