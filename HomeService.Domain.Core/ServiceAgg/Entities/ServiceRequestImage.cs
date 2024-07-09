using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.Entities
{
    public class ServiceRequestImage
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }

        public int ServiceRequestId { get; set; }
        public ServiceRequest? ServiceRequest { get; set; }
    }
}
