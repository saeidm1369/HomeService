using HomeService.Domain.Core.PaymentAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.PaymentAgg.Services
{
    public interface IPaymentService
    {
        Task<PaymentDTO> GetPaymentByIdAsync(int id);
        Task<IEnumerable<PaymentDTO>> GetAllPaymentsAsync();
        Task CreatePaymentAsync(PaymentDTO paymentDto);
        Task UpdatePaymentAsync(PaymentDTO paymentDto);
        Task DeletePaymentAsync(int id);
        Task<PaymentDTO> GetPaymentByTransactionIdAsync(string transactionId);
    }
}
