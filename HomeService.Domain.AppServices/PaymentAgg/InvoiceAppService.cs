using AutoMapper;
using HomeService.Domain.Core.PaymentAgg.AppServices;
using HomeService.Domain.Core.PaymentAgg.Data;
using HomeService.Domain.Core.PaymentAgg.DTOs;
using HomeService.Domain.Core.PaymentAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.AppServices.PaymentAgg
{
    public class InvoiceAppService : IInvoiceAppService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceAppService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<InvoiceDTO> GetInvoiceByIdAsync(int id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            return _mapper.Map<InvoiceDTO>(invoice);
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAllInvoicesAsync()
        {
            var invoices = await _invoiceRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<InvoiceDTO>>(invoices);
        }

        public async Task CreateInvoiceAsync(InvoiceDTO invoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDto);
            await _invoiceRepository.AddAsync(invoice);
        }

        public async Task UpdateInvoiceAsync(InvoiceDTO invoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDto);
            await _invoiceRepository.UpdateAsync(invoice);
        }

        public async Task DeleteInvoiceAsync(int id)
        {
            await _invoiceRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<InvoiceDTO>> GetInvoicesByDateAsync(DateTime date)
        {
            var invoices = await _invoiceRepository.GetInvoicesByDateAsync(date);
            return _mapper.Map<IEnumerable<InvoiceDTO>>(invoices);
        }

        public async Task<IEnumerable<InvoiceDTO>> GetInvoicesByStatusAsync(PaymentStatus status)
        {
            var invoices = await _invoiceRepository.GetInvoicesByStatusAsync(status);
            return _mapper.Map<IEnumerable<InvoiceDTO>>(invoices);
        }

        public async Task<InvoiceDTO> GetInvoiceByNumberAsync(string invoiceNumber)
        {
            var invoice = await _invoiceRepository.GetInvoiceByNumberAsync(invoiceNumber);
            return _mapper.Map<InvoiceDTO>(invoice);

        }
    }
}
