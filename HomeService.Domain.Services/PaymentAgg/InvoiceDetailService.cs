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
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ILogger<InvoiceDetailService> _logger;

        public InvoiceDetailService(IInvoiceDetailRepository invoiceDetailRepository, IMapper mapper, IMemoryCache cache, ILogger<InvoiceDetailService> logger)
        {
            _invoiceDetailRepository = invoiceDetailRepository;
            _mapper = mapper;
            _cache = cache;
            _logger = logger;
        }

        public async Task<InvoiceDetailDTO> GetInvoiceDetailByIdAsync(int id)
        {
            var cacheKey = $"InvoiceDetail_{id}";
            if (!_cache.TryGetValue(cacheKey, out InvoiceDetailDTO invoiceDetailDto))
            {
                var invoiceDetail = await _invoiceDetailRepository.GetByIdAsync(id);
                invoiceDetailDto = _mapper.Map<InvoiceDetailDTO>(invoiceDetail);
                _cache.Set(cacheKey, invoiceDetailDto);
            }

            _logger.LogInformation("Retrieved InvoiceDetail by id: {Id}", id);
            return invoiceDetailDto;
        }

        public async Task<IEnumerable<InvoiceDetailDTO>> GetAllInvoiceDetailsAsync()
        {
            const string cacheKey = "AllInvoiceDetails";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<InvoiceDetailDTO> cachedInvoiceDetails))
            {
                var invoiceDetails = await _invoiceDetailRepository.GetAllAsync();
                cachedInvoiceDetails = _mapper.Map<IEnumerable<InvoiceDetailDTO>>(invoiceDetails);
                _cache.Set(cacheKey, cachedInvoiceDetails);
            }

            _logger.LogInformation("Retrieved all InvoiceDetails from cache");
            return cachedInvoiceDetails;
        }

        public async Task CreateInvoiceDetailAsync(InvoiceDetailDTO invoiceDetailDto)
        {
            var invoiceDetail = _mapper.Map<InvoiceDetail>(invoiceDetailDto);
            await _invoiceDetailRepository.AddAsync(invoiceDetail);
            _logger.LogInformation("InvoiceDetail created: {@InvoiceDetail}", invoiceDetail);
            _cache.Remove("AllInvoiceDetails");
        }

        public async Task UpdateInvoiceDetailAsync(InvoiceDetailDTO invoiceDetailDto)
        {
            var invoiceDetail = _mapper.Map<InvoiceDetail>(invoiceDetailDto);
            await _invoiceDetailRepository.UpdateAsync(invoiceDetail);
            _logger.LogInformation("InvoiceDetail updated: {@InvoiceDetail}", invoiceDetail);
            _cache.Remove("AllInvoiceDetails");
            _cache.Remove($"InvoiceDetail_{invoiceDetail.Id}");
        }

        public async Task DeleteInvoiceDetailAsync(int id)
        {
            await _invoiceDetailRepository.DeleteAsync(id);
            _logger.LogInformation("InvoiceDetail deleted: {Id}", id);
            _cache.Remove("AllInvoiceDetails");
            _cache.Remove($"InvoiceDetail_{id}");
        }

        public async Task<IEnumerable<InvoiceDetailDTO>> GetDetailsByInvoiceIdAsync(int invoiceId)
        {
            var cacheKey = $"InvoiceDetails_{invoiceId}";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<InvoiceDetailDTO> cachedDetails))
            {
                var details = await _invoiceDetailRepository.GetDetailsByInvoiceIdAsync(invoiceId);
                cachedDetails = _mapper.Map<IEnumerable<InvoiceDetailDTO>>(details);
                _cache.Set(cacheKey, cachedDetails);
            }

            _logger.LogInformation("Retrieved InvoiceDetails by InvoiceId: {InvoiceId}", invoiceId);
            return cachedDetails;
        }
    }
}
