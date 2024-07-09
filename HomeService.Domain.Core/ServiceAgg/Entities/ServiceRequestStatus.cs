using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.Entities
{
    public class ServiceRequestStatus
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<ServiceRequest>? ServiceRequests { get; set; }

        public static readonly ServiceRequestStatus Pending = new ServiceRequestStatus { Id = 1, Name = "Pending" };
        public static readonly ServiceRequestStatus Accepted = new ServiceRequestStatus { Id = 2, Name = "Accepted" };
        public static readonly ServiceRequestStatus InProgress = new ServiceRequestStatus { Id = 3, Name = "InProgress" };
        public static readonly ServiceRequestStatus Completed = new ServiceRequestStatus { Id = 4, Name = "Completed" };
        public static readonly ServiceRequestStatus Cancelled = new ServiceRequestStatus { Id = 5, Name = "Cancelled" };
    }
}
