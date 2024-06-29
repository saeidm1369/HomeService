using BaseFramework;
using HomeService.Domain.Core.PaymentAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.PaymentAgg.Data
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Task<IEnumerable<Invoice>> GetInvoicesByDateAsync(DateTime date);
        Task<IEnumerable<Invoice>> GetInvoicesByStatusAsync(PaymentStatus status);
        Task<Invoice> GetInvoiceByNumberAsync(string invoiceNumber);
    }
}
