using HomeService.Domain.Core.UserAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.PaymentAgg.DTOs
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public PaymentDTO Payment { get; set; }
        public UserDTO User { get; set; }
        public List<InvoiceDetailDTO> InvoiceDetails { get; set; }
    }
}
