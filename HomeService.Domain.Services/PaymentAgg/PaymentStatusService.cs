using AutoMapper;
using HomeService.Domain.Core.PaymentAgg.Data;
using HomeService.Domain.Core.PaymentAgg.DTOs;
using HomeService.Domain.Core.PaymentAgg.Entities;
using HomeService.Domain.Core.PaymentAgg.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Services.PaymentAgg
{
    public class PaymentStatusService : IPaymentStatusService
    {
        private readonly IPaymentStatusRepository _paymentStatusRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ILogger<PaymentStatusService> _logger;

        public PaymentStatusService(IPaymentStatusRepository paymentStatusRepository, IMapper mapper, IMemoryCache cache, ILogger<PaymentStatusService> logger)
        {
            _paymentStatusRepository = paymentStatusRepository;
            _mapper = mapper;
            _cache = cache;
            _logger = logger;
        }

        public async Task<PaymentStatusDTO> GetPaymentStatusByIdAsync(int id)
        {
            var cacheKey = $"PaymentStatus_{id}";

            if (!_cache.TryGetValue(cacheKey, out PaymentStatusDTO paymentStatusDto))
            {
                var paymentStatus = await _paymentStatusRepository.GetByIdAsync(id);
                if (paymentStatus == null)
                {
                    _logger.LogWarning("PaymentStatus not found: {Id}", id);
                    throw new KeyNotFoundException("PaymentStatus not found.");
                }

                paymentStatusDto = _mapper.Map<PaymentStatusDTO>(paymentStatus);
                _cache.Set(cacheKey, paymentStatusDto);
            }

            _logger.LogInformation("Retrieved PaymentStatus by id: {Id}", id);
            return paymentStatusDto;
        }

        public async Task<IEnumerable<PaymentStatusDTO>> GetAllPaymentStatusesAsync()
        {
            const string cacheKey = "AllPaymentStatuses";

            if (!_cache.TryGetValue(cacheKey, out IEnumerable<PaymentStatusDTO> cachedPaymentStatuses))
            {
                var paymentStatuses = await _paymentStatusRepository.GetAllAsync();
                cachedPaymentStatuses = _mapper.Map<IEnumerable<PaymentStatusDTO>>(paymentStatuses);
                _cache.Set(cacheKey, cachedPaymentStatuses);
            }

            _logger.LogInformation("Retrieved all PaymentStatuses from cache");
            return cachedPaymentStatuses;
        }

        public async Task CreatePaymentStatusAsync(PaymentStatusDTO paymentStatusDto)
        {
            var paymentStatus = _mapper.Map<PaymentStatus>(paymentStatusDto);
            await _paymentStatusRepository.AddAsync(paymentStatus);
            _logger.LogInformation("PaymentStatus created: {@PaymentStatus}", paymentStatus);
            _cache.Remove("AllPaymentStatuses");
        }

        public async Task UpdatePaymentStatusAsync(PaymentStatusDTO paymentStatusDto)
        {
            var paymentStatus = _mapper.Map<PaymentStatus>(paymentStatusDto);
            await _paymentStatusRepository.UpdateAsync(paymentStatus);
            _logger.LogInformation("PaymentStatus updated: {@PaymentStatus}", paymentStatus);
            _cache.Remove("AllPaymentStatuses");
            _cache.Remove($"PaymentStatus_{paymentStatus.Id}");
        }

        public async Task DeletePaymentStatusAsync(int id)
        {
            await _paymentStatusRepository.DeleteAsync(id);
            _logger.LogInformation("PaymentStatus deleted: {Id}", id);
            _cache.Remove("AllPaymentStatuses");
            _cache.Remove($"PaymentStatus_{id}");
        }

        public async Task<PaymentStatusDTO> GetPaymentStatusByNameAsync(string name)
        {
            var cacheKey = $"PaymentStatusByName_{name}";

            if (!_cache.TryGetValue(cacheKey, out PaymentStatusDTO paymentStatusDto))
            {
                var paymentStatus = await _paymentStatusRepository.GetByNameAsync(name);
                if (paymentStatus == null)
                {
                    _logger.LogWarning("PaymentStatus not found: {Name}", name);
                    throw new KeyNotFoundException("PaymentStatus not found.");
                }

                paymentStatusDto = _mapper.Map<PaymentStatusDTO>(paymentStatus);
                _cache.Set(cacheKey, paymentStatusDto);
            }

            _logger.LogInformation("Retrieved PaymentStatus by Name: {Name}", name);
            return paymentStatusDto;
        }
    }
}

