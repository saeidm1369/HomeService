using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.PaymentAgg.Entities
{
    public class PaymentStatus
    {
        public int Id { get; set; }
        public string? StatusName { get; set; }

        public ICollection<Payment>? Payments { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }
    }
}
