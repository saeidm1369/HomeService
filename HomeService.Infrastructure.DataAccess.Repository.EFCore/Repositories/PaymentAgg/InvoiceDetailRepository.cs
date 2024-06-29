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
    public class InvoiceDetailRepository : Repository<InvoiceDetail> , IInvoiceDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public InvoiceDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InvoiceDetail>> GetDetailsByInvoiceIdAsync(int invoiceId)
        {
            return await _context.InvoiceDetails
                             .Where(id => id.InvoiceId == invoiceId)
                             .ToListAsync();
        }
    }
}
