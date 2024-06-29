using HomeService.Domain.Core.PaymentAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.PaymentAgg.AppServices
{
    public interface IPaymentStatusAppService
    {
        Task<PaymentStatusDTO> GetPaymentStatusByIdAsync(int id);
        Task<IEnumerable<PaymentStatusDTO>> GetAllPaymentStatusesAsync();
        Task CreatePaymentStatusAsync(PaymentStatusDTO paymentStatusDto);
        Task UpdatePaymentStatusAsync(PaymentStatusDTO paymentStatusDto);
        Task DeletePaymentStatusAsync(int id);
        Task<PaymentStatusDTO> GetPaymentStatusByNameAsync(string name);
    }
}
