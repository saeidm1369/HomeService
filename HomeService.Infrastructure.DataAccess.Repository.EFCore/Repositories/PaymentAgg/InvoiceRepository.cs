using BaseFramework;
using HomeService.Domain.Core.PaymentAgg.Data;
using HomeService.Domain.Core.PaymentAgg.Entities;
using HomeService.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Infrastructure.DataAccess.Repository.EFCore.Repositories.PaymentAgg
{
    public class InvoiceRepository : Repository<Invoice> , IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;
        public InvoiceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Invoice> GetInvoiceByNumberAsync(string invoiceNumber)
        {
            return await _context.Invoices.FirstOrDefaultAsync(i => i.InvoiceNumber == invoiceNumber);
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByDateAsync(DateTime date)
        {
            return await _context.Invoices
                                 .Where(i => i.InvoiceDate.Date == date.Date)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByStatusAsync(PaymentStatus status)
        {
            return await _context.Invoices
                                 .Where(i => i.PaymentStatus == status)
                                 .ToListAsync();
        }
    }
}
