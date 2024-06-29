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
    public class PaymentStatusRepository : Repository<PaymentStatus> , IPaymentStatusRepository
    {
        private readonly ApplicationDbContext _context;
        public PaymentStatusRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PaymentStatus> GetByNameAsync(string name)
        {
            return await _context.PaymentStatuses.FirstOrDefaultAsync(p => p.StatusName == name);
        }
    }
}
