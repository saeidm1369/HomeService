using HomeService.Domain.Core.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.Entities
{
    public class ServiceSugesstion
    {
        public int Id { get; set; }
        public decimal ServiceSugesstionPrice { get; set; }
        public DateTime ServiceSugesstionDate { get; set; }

        public int ServiceRequestId { get; set; }
        public ServiceRequest ServiceRequest { get; set; }

        public string ExpertId { get; set; }
        public User Expert { get; set; }
    }
}
