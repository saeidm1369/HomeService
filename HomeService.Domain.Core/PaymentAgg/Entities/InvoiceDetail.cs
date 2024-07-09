using HomeService.Domain.Core.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.PaymentAgg.Entities
{
    public class InvoiceDetail
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }

        public int InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }

    }
}
