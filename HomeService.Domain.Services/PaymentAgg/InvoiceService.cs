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
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly MemoryCacheEntryOptions _cacheOptions;
        private readonly ILogger<InvoiceService> _logger;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper, IMemoryCache cache, ILogger<InvoiceService> logger)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _cache = cache;
            _cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(30))
                .SetAbsoluteExpiration(TimeSpan.FromHours(1));
            _logger = logger;
        }

        public async Task<InvoiceDTO> GetInvoiceByIdAsync(int id)
        {
            var cacheKey = $"Invoice_{id}";

            if (!_cache.TryGetValue(cacheKey, out InvoiceDTO invoiceDto))
            {
                var invoice = await _invoiceRepository.GetByIdAsync(id);
                if (invoice == null)
                {
                    _logger.LogWarning("Invoice not found: {Id}", id);
                    throw new KeyNotFoundException("Invoice not found.");
                }

                invoiceDto = _mapper.Map<InvoiceDTO>(invoice);
                _cache.Set(cacheKey, invoiceDto, _cacheOptions);
            }

            _logger.LogInformation("Retrieved Invoice by id: {Id}", id);
            return invoiceDto;
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAllInvoicesAsync()
        {
            const string cacheKey = "AllInvoices";

            if (!_cache.TryGetValue(cacheKey, out IEnumerable<InvoiceDTO> cachedInvoices))
            {
                var invoices = await _invoiceRepository.GetAllAsync();
                cachedInvoices = _mapper.Map<IEnumerable<InvoiceDTO>>(invoices);
                _cache.Set(cacheKey, cachedInvoices, _cacheOptions);
            }

            _logger.LogInformation("Retrieved all Invoices from cache");
            return cachedInvoices;
        }

        public async Task CreateInvoiceAsync(InvoiceDTO invoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDto);
            await _invoiceRepository.AddAsync(invoice);
            _logger.LogInformation("Invoice created: {@Invoice}", invoice);
            _cache.Remove("AllInvoices");
        }

        public async Task UpdateInvoiceAsync(InvoiceDTO invoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDto);
            await _invoiceRepository.UpdateAsync(invoice);
            _logger.LogInformation("Invoice updated: {@Invoice}", invoice);
            _cache.Remove($"Invoice_{invoice.Id}");
            _cache.Remove("AllInvoices");
        }

        public async Task DeleteInvoiceAsync(int id)
        {
            await _invoiceRepository.DeleteAsync(id);
            _logger.LogInformation("Invoice deleted: {Id}", id);
            _cache.Remove($"Invoice_{id}");
            _cache.Remove("AllInvoices");
        }

        public async Task<IEnumerable<InvoiceDTO>> GetInvoicesByDateAsync(DateTime date)
        {
            var cacheKey = $"InvoicesByDate_{date.ToShortDateString()}";

            if (!_cache.TryGetValue(cacheKey, out IEnumerable<InvoiceDTO> cachedInvoices))
            {
                var invoices = await _invoiceRepository.GetInvoicesByDateAsync(date);
                cachedInvoices = _mapper.Map<IEnumerable<InvoiceDTO>>(invoices);
                _cache.Set(cacheKey, cachedInvoices, _cacheOptions);
            }

            _logger.LogInformation("Retrieved Invoices by Date: {Date}", date);
            return cachedInvoices;
        }

        public async Task<IEnumerable<InvoiceDTO>> GetInvoicesByStatusAsync(PaymentStatus status)
        {
            var cacheKey = $"InvoicesByStatus_{status}";

            if (!_cache.TryGetValue(cacheKey, out IEnumerable<InvoiceDTO> cachedInvoices))
            {
                var invoices = await _invoiceRepository.GetInvoicesByStatusAsync(status);
                cachedInvoices = _mapper.Map<IEnumerable<InvoiceDTO>>(invoices);
                _cache.Set(cacheKey, cachedInvoices, _cacheOptions);
            }

            _logger.LogInformation("Retrieved Invoices by Status: {Status}", status);
            return cachedInvoices;
        }

        public async Task<InvoiceDTO> GetInvoiceByNumberAsync(string invoiceNumber)
        {
            var cacheKey = $"InvoiceByNumber_{invoiceNumber}";

            if (!_cache.TryGetValue(cacheKey, out InvoiceDTO invoiceDto))
            {
                var invoice = await _invoiceRepository.GetInvoiceByNumberAsync(invoiceNumber);
                if (invoice == null)
                {
                    _logger.LogWarning("Invoice not found: {InvoiceNumber}", invoiceNumber);
                    throw new KeyNotFoundException("Invoice not found.");
                }

                invoiceDto = _mapper.Map<InvoiceDTO>(invoice);
                _cache.Set(cacheKey, invoiceDto, _cacheOptions);
            }

            _logger.LogInformation("Retrieved Invoice by Number: {InvoiceNumber}", invoiceNumber);
            return invoiceDto;
        }
    }
}