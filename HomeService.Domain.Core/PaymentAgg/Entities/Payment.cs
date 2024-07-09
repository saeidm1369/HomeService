using HomeService.Domain.Core.ServiceAgg.Entities;
using HomeService.Domain.Core.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.PaymentAgg.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? TransactionId { get; set; }

        public string? UserId { get; set; }
        public User? User { get; set; }

        public int ServiceRequestId { get; set; }
        public ServiceRequest? ServiceRequest { get; set; }

        public int PaymentStatusId { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }

        public ICollection<Invoice>? Invoices { get; set; }
    }
}
