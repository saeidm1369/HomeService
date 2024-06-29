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
    public class ServiceRequestStatusService : IServiceRequestStatusService
    {
        private readonly IServiceRequestStatusRepository _serviceRequestStatusRepository;
        private readonly IServiceRequestRepository _serviceRequestRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ServiceRequestStatusService> _logger;

        public ServiceRequestStatusService(
            IServiceRequestStatusRepository serviceRequestStatusRepository,
            IServiceRequestRepository serviceRequestRepository,
            IMapper mapper,
            IMemoryCache cache,
            ILogger<ServiceRequestStatusService> logger)
        {
            _serviceRequestStatusRepository = serviceRequestStatusRepository;
            _serviceRequestRepository = serviceRequestRepository;
            _mapper = mapper;
            _cache = cache;
            _logger = logger;
        }

        public async Task<ServiceRequestStatusDTO> GetServiceRequestStatusByIdAsync(int id)
        {
            var serviceRequestStatus = await _serviceRequestStatusRepository.GetByIdAsync(id);
            if (serviceRequestStatus == null)
            {
                _logger.LogWarning("ServiceRequestStatus not found: {Id}", id);
                throw new KeyNotFoundException("ServiceRequestStatus not found.");
            }

            _logger.LogInformation("Retrieved ServiceRequestStatus by id: {Id}", id);
            return _mapper.Map<ServiceRequestStatusDTO>(serviceRequestStatus);
        }

        public async Task<IEnumerable<ServiceRequestStatusDTO>> GetAllServiceRequestStatusesAsync()
        {
            if (!_cache.TryGetValue("AllServiceRequestStatuses", out IEnumerable<ServiceRequestStatusDTO> cachedServiceRequestStatuses))
            {
                var serviceRequestStatuses = await _serviceRequestStatusRepository.GetAllAsync();
                cachedServiceRequestStatuses = _mapper.Map<IEnumerable<ServiceRequestStatusDTO>>(serviceRequestStatuses);
                _cache.Set("AllServiceRequestStatuses", cachedServiceRequestStatuses);
            }

            _logger.LogInformation("Retrieved all ServiceRequestStatuses from cache");
            return cachedServiceRequestStatuses;
        }

        public async Task<ServiceRequestStatusDTO> CreateServiceRequestStatusAsync(ServiceRequestStatusDTO serviceRequestStatusDto)
        {
            var serviceRequestStatus = _mapper.Map<ServiceRequestStatus>(serviceRequestStatusDto);
            await _serviceRequestStatusRepository.AddAsync(serviceRequestStatus);
            _logger.LogInformation("ServiceRequestStatus created: {@ServiceRequestStatus}", serviceRequestStatus);
            _cache.Remove("AllServiceRequestStatuses");
            return _mapper.Map<ServiceRequestStatusDTO>(serviceRequestStatus);
        }

        public async Task<ServiceRequestStatusDTO> UpdateServiceRequestStatusAsync(ServiceRequestStatusDTO serviceRequestStatusDto)
        {
            var serviceRequestStatus = _mapper.Map<ServiceRequestStatus>(serviceRequestStatusDto);
            await _serviceRequestStatusRepository.UpdateAsync(serviceRequestStatus);
            _logger.LogInformation("ServiceRequestStatus updated: {@ServiceRequestStatus}", serviceRequestStatus);
            _cache.Remove("AllServiceRequestStatuses");
            return _mapper.Map<ServiceRequestStatusDTO>(serviceRequestStatus);
        }

        public async Task<bool> DeleteServiceRequestStatusAsync(int id)
        {
            var result = await _serviceRequestStatusRepository.DeleteAsync(id);
            _logger.LogInformation("ServiceRequestStatus deleted: {Id}", id);
            _cache.Remove("AllServiceRequestStatuses");
            return result;
        }

        public async Task ChangeRequestStatusAsync(int requestId, int newStatusId)
        {
            var serviceRequest = await _serviceRequestRepository.GetByIdAsync(requestId);

            if (serviceRequest == null)
            {
                throw new Exception("درخواست مورد نظر یافت نشد.");
            }

            var newStatus = await _serviceRequestStatusRepository.GetByIdAsync(newStatusId);

            if (newStatus == null)
            {
                throw new Exception("وضعیت جدید معتبر نیست.");
            }

            // تغییر وضعیت درخواست
            serviceRequest.ServiceRequestStatusId = newStatusId;

            // ذخیره تغییرات
            await _serviceRequestRepository.UpdateAsync(serviceRequest);
        }
    }
}
