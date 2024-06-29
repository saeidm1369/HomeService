using AutoMapper;
using HomeService.Domain.Core.ServiceAgg.Data;
using HomeService.Domain.Core.ServiceAgg.DTOs;
using HomeService.Domain.Core.ServiceAgg.Entities;
using HomeService.Domain.Core.ServiceAgg.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Services.ServiceAgg
{
    public class ServiceService : IServiceService
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ServiceService> _logger;

        public ServiceService(IMapper mapper, IServiceRepository serviceRepository, IMemoryCache cache, ILogger<ServiceService> logger)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
            _cache = cache;
            _logger = logger;
        }

        public async Task<IEnumerable<ServiceDTO>> GetAllServicesAsync()
        {
            var cacheKey = "AllServices";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<Service> services))
            {
                services = await _serviceRepository.GetAllAsync();
                if (services != null && services.Any())
                {
                    _cache.Set(cacheKey, services, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(30),
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
                    });
                }
            }
            return _mapper.Map<IEnumerable<ServiceDTO>>(services);
        }

        public async Task<ServiceDTO> GetServiceByIdAsync(int id)
        {
            var cacheKey = $"Service_{id}";
            if (!_cache.TryGetValue(cacheKey, out Service service))
            {
                service = await _serviceRepository.GetByIdAsync(id);
                if (service != null)
                {
                    _cache.Set(cacheKey, service, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(30),
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
                    });
                }
            }
            return _mapper.Map<ServiceDTO>(service);
        }

        public async Task AddServiceAsync(ServiceDTO serviceDto)
        {
            var service = _mapper.Map<Service>(serviceDto);
            await _serviceRepository.AddAsync(service);
            _cache.Remove("AllServices"); // Invalidate the cache
        }

        public async Task UpdateServiceAsync(ServiceDTO serviceDto)
        {
            var service = _mapper.Map<Service>(serviceDto);
            await _serviceRepository.UpdateAsync(service);
            _cache.Remove($"Service_{service.Id}");
            _cache.Remove("AllServices"); // Invalidate the cache
        }

        public async Task DeleteServiceAsync(int id)
        {
            await _serviceRepository.DeleteAsync(id);
            _cache.Remove($"Service_{id}");
            _cache.Remove("AllServices"); // Invalidate the cache
        }
    }
}
