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
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly IMapper _mapper;
        private readonly IServiceRequestRepository _serviceRequestRepository;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ServiceRequestService> _logger;

        public ServiceRequestService(IMapper mapper, IServiceRequestRepository serviceRequestRepository, IMemoryCache cache, ILogger<ServiceRequestService> logger)
        {
            _mapper = mapper;
            _serviceRequestRepository = serviceRequestRepository;
            _cache = cache;
            _logger = logger;
        }

        public async Task<IEnumerable<ServiceRequestDTO>> GetAllServiceRequestsAsync()
        {
            if (!_cache.TryGetValue("AllServiceRequests", out IEnumerable<ServiceRequestDTO> cachedServiceRequests))
            {
                var serviceRequests = await _serviceRequestRepository.GetAllAsync();
                cachedServiceRequests = _mapper.Map<IEnumerable<ServiceRequestDTO>>(serviceRequests);
                _cache.Set("AllServiceRequests", cachedServiceRequests);
            }

            _logger.LogInformation("Retrieved all ServiceRequests from cache");
            return cachedServiceRequests;
        }

        public async Task<ServiceRequestDTO> GetServiceRequestByIdAsync(int id)
        {
            var serviceRequest = await _serviceRequestRepository.GetByIdAsync(id);
            if (serviceRequest == null)
            {
                _logger.LogWarning("ServiceRequest not found: {Id}", id);
                throw new KeyNotFoundException("ServiceRequest not found.");
            }

            _logger.LogInformation("Retrieved ServiceRequest by id: {Id}", id);
            return _mapper.Map<ServiceRequestDTO>(serviceRequest);
        }

        public async Task AddServiceRequestAsync(ServiceRequestDTO serviceRequestDto)
        {
            var serviceRequest = _mapper.Map<ServiceRequest>(serviceRequestDto);
            await _serviceRequestRepository.AddAsync(serviceRequest);
            _logger.LogInformation("ServiceRequest created: {@ServiceRequest}", serviceRequest);
            _cache.Remove("AllServiceRequests");
        }

        public async Task UpdateServiceRequestAsync(ServiceRequestDTO serviceRequestDto)
        {
            var serviceRequest = _mapper.Map<ServiceRequest>(serviceRequestDto);
            await _serviceRequestRepository.UpdateAsync(serviceRequest);
            _logger.LogInformation("ServiceRequest updated: {@ServiceRequest}", serviceRequest);
            _cache.Remove("AllServiceRequests");
        }

        public async Task DeleteServiceRequestAsync(int id)
        {
            await _serviceRequestRepository.DeleteAsync(id);
            _logger.LogInformation("ServiceRequest deleted: {Id}", id);
            _cache.Remove("AllServiceRequests");
        }
    }
}
