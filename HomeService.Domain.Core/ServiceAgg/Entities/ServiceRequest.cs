using HomeService.Domain.Core.PaymentAgg.Entities;
using HomeService.Domain.Core.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.Entities
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime RequestDate { get; set; }

        public string? UserId { get; set; }
        public User? User { get; set; }

        public int ServiceId { get; set; }
        public Service? Service { get; set; }

        public int ServiceRequestStatusId { get; set; }
        public ServiceRequestStatus? ServiceRequestStatus { get; set; }

        public ICollection<Review>? Reviews { get; set; }
        public ICollection<ServiceSugesstion>? ServiceSugesstions { get; set; }
        public ICollection<ServiceRequestImage>? ServiceRequestImages { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
