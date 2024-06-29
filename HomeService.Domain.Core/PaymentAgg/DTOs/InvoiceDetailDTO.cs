using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.PaymentAgg.DTOs
{
    public class InvoiceDetailDTO
    {
        public int Id { get; set; }
        public InvoiceDTO Invoice { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
