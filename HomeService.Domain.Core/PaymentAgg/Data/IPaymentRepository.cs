using BaseFramework;
using HomeService.Domain.Core.PaymentAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.PaymentAgg.Data
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<Payment> GetPaymentByTransactionIdAsync(string transactionId);
    }
}
