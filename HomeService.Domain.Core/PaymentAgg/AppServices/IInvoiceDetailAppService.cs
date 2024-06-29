using HomeService.Domain.Core.PaymentAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.PaymentAgg.AppServices
{
    public interface IInvoiceDetailAppService
    {
        Task<InvoiceDetailDTO> GetInvoiceDetailByIdAsync(int id);
        Task<IEnumerable<InvoiceDetailDTO>> GetAllInvoiceDetailsAsync();
        Task CreateInvoiceDetailAsync(InvoiceDetailDTO invoiceDetailDto);
        Task UpdateInvoiceDetailAsync(InvoiceDetailDTO invoiceDetailDto);
        Task DeleteInvoiceDetailAsync(int id);
        Task<IEnumerable<InvoiceDetailDTO>> GetDetailsByInvoiceIdAsync(int invoiceId);
    }
}
