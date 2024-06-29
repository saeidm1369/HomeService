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
    public class ServiceRequestImageService : IServiceRequestImageService
    {
        private readonly IServiceRequestImageRepository _serviceRequestImageRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ServiceRequestImageService> _logger;

        public ServiceRequestImageService(IServiceRequestImageRepository serviceRequestImageRepository, IMapper mapper, IMemoryCache cache, ILogger<ServiceRequestImageService> logger)
        {
            _serviceRequestImageRepository = serviceRequestImageRepository;
            _mapper = mapper;
            _cache = cache;
            _logger = logger;
        }

        public async Task<ServiceRequestImageDTO> GetServiceRequestImageByIdAsync(int id)
        {
            var serviceRequestImage = await _serviceRequestImageRepository.GetByIdAsync(id);
            if (serviceRequestImage == null)
            {
                _logger.LogWarning("ServiceRequestImage not found: {Id}", id);
                throw new KeyNotFoundException("ServiceRequestImage not found.");
            }

            _logger.LogInformation("Retrieved ServiceRequestImage by id: {Id}", id);
            return _mapper.Map<ServiceRequestImageDTO>(serviceRequestImage);
        }

        public async Task<IEnumerable<ServiceRequestImageDTO>> GetAllServiceRequestImagesAsync()
        {
            if (!_cache.TryGetValue("AllServiceRequestImages", out IEnumerable<ServiceRequestImageDTO> cachedServiceRequestImages))
            {
                var serviceRequestImages = await _serviceRequestImageRepository.GetAllAsync();
                cachedServiceRequestImages = _mapper.Map<IEnumerable<ServiceRequestImageDTO>>(serviceRequestImages);
                _cache.Set("AllServiceRequestImages", cachedServiceRequestImages);
            }

            _logger.LogInformation("Retrieved all ServiceRequestImages from cache");
            return cachedServiceRequestImages;
        }

        public async Task<ServiceRequestImageDTO> CreateServiceRequestImageAsync(ServiceRequestImageDTO serviceRequestImageDto)
        {
            var serviceRequestImage = _mapper.Map<ServiceRequestImage>(serviceRequestImageDto);
            await _serviceRequestImageRepository.AddAsync(serviceRequestImage);
            _logger.LogInformation("ServiceRequestImage created: {@ServiceRequestImage}", serviceRequestImage);
            _cache.Remove("AllServiceRequestImages");
            return _mapper.Map<ServiceRequestImageDTO>(serviceRequestImage);
        }

        public async Task<ServiceRequestImageDTO> UpdateServiceRequestImageAsync(ServiceRequestImageDTO serviceRequestImageDto)
        {
            var serviceRequestImage = _mapper.Map<ServiceRequestImage>(serviceRequestImageDto);
            await _serviceRequestImageRepository.UpdateAsync(serviceRequestImage);
            _logger.LogInformation("ServiceRequestImage updated: {@ServiceRequestImage}", serviceRequestImage);
            _cache.Remove("AllServiceRequestImages");
            return _mapper.Map<ServiceRequestImageDTO>(serviceRequestImage);
        }

        public async Task<bool> DeleteServiceRequestImageAsync(int id)
        {
            var result = await _serviceRequestImageRepository.DeleteAsync(id);
            _logger.LogInformation("ServiceRequestImage deleted: {Id}", id);
            _cache.Remove("AllServiceRequestImages");
            return result;
        }
    }
}
