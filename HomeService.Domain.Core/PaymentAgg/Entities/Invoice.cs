using HomeService.Domain.Core.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.PaymentAgg.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public int PaymentStatusId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
