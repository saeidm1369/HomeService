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
    public class InvoiceDetailAppService : IInvoiceDetailAppService
    {
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;
        private readonly IMapper _mapper;

        public InvoiceDetailAppService(IInvoiceDetailRepository invoiceDetailRepository, IMapper mapper)
        {
            _invoiceDetailRepository = invoiceDetailRepository;
            _mapper = mapper;
        }

        public async Task<InvoiceDetailDTO> GetInvoiceDetailByIdAsync(int id)
        {
            var invoiceDetail = await _invoiceDetailRepository.GetByIdAsync(id);
            return _mapper.Map<InvoiceDetailDTO>(invoiceDetail);
        }

        public async Task<IEnumerable<InvoiceDetailDTO>> GetAllInvoiceDetailsAsync()
        {
            var invoiceDetails = await _invoiceDetailRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<InvoiceDetailDTO>>(invoiceDetails);
        }

        public async Task CreateInvoiceDetailAsync(InvoiceDetailDTO invoiceDetailDto)
        {
            var invoiceDetail = _mapper.Map<InvoiceDetail>(invoiceDetailDto);
            await _invoiceDetailRepository.AddAsync(invoiceDetail);
        }

        public async Task UpdateInvoiceDetailAsync(InvoiceDetailDTO invoiceDetailDto)
        {
            var invoiceDetail = _mapper.Map<InvoiceDetail>(invoiceDetailDto);
            await _invoiceDetailRepository.UpdateAsync(invoiceDetail);
        }

        public async Task DeleteInvoiceDetailAsync(int id)
        {
            await _invoiceDetailRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<InvoiceDetailDTO>> GetDetailsByInvoiceIdAsync(int invoiceId)
        {
            var details = await _invoiceDetailRepository.GetDetailsByInvoiceIdAsync(invoiceId);
            return _mapper.Map<IEnumerable<InvoiceDetailDTO>>(details);
        }
    }
}
