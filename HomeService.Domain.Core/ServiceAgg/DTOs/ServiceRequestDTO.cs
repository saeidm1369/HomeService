using HomeService.Domain.Core.UserAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.DTOs
{
    public class ServiceRequestDTO
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public ServiceDTO Service { get; set; }
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
        public ServiceRequestStatusDTO ServiceRequestStatus { get; set; }
        public List<ServiceRequestImageDTO> ServiceRequestImages { get; set; }
    }
}
