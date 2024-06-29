using HomeService.Domain.Core.PaymentAgg.DTOs;
using HomeService.Domain.Core.PaymentAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.PaymentAgg.Services
{
    public interface IInvoiceService
    {
        Task<InvoiceDTO> GetInvoiceByIdAsync(int id);
        Task<IEnumerable<InvoiceDTO>> GetAllInvoicesAsync();
        Task CreateInvoiceAsync(InvoiceDTO invoiceDto);
        Task UpdateInvoiceAsync(InvoiceDTO invoiceDto);
        Task DeleteInvoiceAsync(int id);
        Task<IEnumerable<InvoiceDTO>> GetInvoicesByDateAsync(DateTime date);
        Task<IEnumerable<InvoiceDTO>> GetInvoicesByStatusAsync(PaymentStatus status);
        Task<InvoiceDTO> GetInvoiceByNumberAsync(string invoiceNumber);
    }
}
