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
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper, IMemoryCache cache, ILogger<PaymentService> logger)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            _cache = cache;
            _logger = logger;
        }

        public async Task<PaymentDTO> GetPaymentByIdAsync(int id)
        {
            var cacheKey = $"Payment_{id}";

            if (!_cache.TryGetValue(cacheKey, out PaymentDTO paymentDto))
            {
                var payment = await _paymentRepository.GetByIdAsync(id);
                if (payment == null)
                {
                    _logger.LogWarning("Payment not found: {Id}", id);
                    throw new KeyNotFoundException("Payment not found.");
                }

                paymentDto = _mapper.Map<PaymentDTO>(payment);
                _cache.Set(cacheKey, paymentDto);
            }

            _logger.LogInformation("Retrieved Payment by id: {Id}", id);
            return paymentDto;
        }

        public async Task<IEnumerable<PaymentDTO>> GetAllPaymentsAsync()
        {
            const string cacheKey = "AllPayments";

            if (!_cache.TryGetValue(cacheKey, out IEnumerable<PaymentDTO> cachedPayments))
            {
                var payments = await _paymentRepository.GetAllAsync();
                cachedPayments = _mapper.Map<IEnumerable<PaymentDTO>>(payments);
                _cache.Set(cacheKey, cachedPayments);
            }

            _logger.LogInformation("Retrieved all Payments from cache");
            return cachedPayments;
        }

        public async Task CreatePaymentAsync(PaymentDTO paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            await _paymentRepository.AddAsync(payment);
            _logger.LogInformation("Payment created: {@Payment}", payment);
            _cache.Remove("AllPayments");
        }

        public async Task UpdatePaymentAsync(PaymentDTO paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            await _paymentRepository.UpdateAsync(payment);
            _logger.LogInformation("Payment updated: {@Payment}", payment);
            _cache.Remove("AllPayments");
            _cache.Remove($"Payment_{payment.Id}");
        }

        public async Task DeletePaymentAsync(int id)
        {
            await _paymentRepository.DeleteAsync(id);
            _logger.LogInformation("Payment deleted: {Id}", id);
            _cache.Remove("AllPayments");
            _cache.Remove($"Payment_{id}");
        }

        public async Task<PaymentDTO> GetPaymentByTransactionIdAsync(string transactionId)
        {
            var cacheKey = $"PaymentByTransactionId_{transactionId}";

            if (!_cache.TryGetValue(cacheKey, out PaymentDTO paymentDto))
            {
                var payment = await _paymentRepository.GetPaymentByTransactionIdAsync(transactionId);
                if (payment == null)
                {
                    _logger.LogWarning("Payment not found: {TransactionId}", transactionId);
                    throw new KeyNotFoundException("Payment not found.");
                }

                paymentDto = _mapper.Map<PaymentDTO>(payment);
                _cache.Set(cacheKey, paymentDto);
            }

            _logger.LogInformation("Retrieved Payment by TransactionId: {TransactionId}", transactionId);
            return paymentDto;
        }
    }
}
