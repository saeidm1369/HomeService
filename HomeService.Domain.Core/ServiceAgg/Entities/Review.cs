using HomeService.Domain.Core.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }

        public int ServiceRequestId { get; set; }
        public ServiceRequest? ServiceRequest { get; set; }

        public string? UserId { get; set; }
        public User? User { get; set; }

        public string? ExpertId { get; set; }
        public User? Expert { get; set; }

        public int ServiceId { get; set; }
        public Service? service { get; set; }

    }
}
