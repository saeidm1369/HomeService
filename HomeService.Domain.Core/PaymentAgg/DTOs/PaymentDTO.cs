using HomeService.Domain.Core.ServiceAgg.DTOs;
using HomeService.Domain.Core.UserAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.PaymentAgg.DTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TransactionId { get; set; }
        public UserDTO User { get; set; }
        public ServiceRequestDTO ServiceRequest { get; set; }
        public PaymentStatusDTO PaymentStatus { get; set; }
    }
}
