using HomeService.Domain.Core.UserAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.DTOs
{
    public class ServiceSugesstionDTO
    {
        public int Id { get; set; }
        public UserDTO Expert { get; set; }
        public ServiceRequestDTO ServiceRequest { get; set; }
        public decimal ServiceSugesstionPrice { get; set; }
        public string ServiceSugesstionDescription { get; set; }
        public DateTime ServiceSugesstionDate { get; set; }
    }
}
