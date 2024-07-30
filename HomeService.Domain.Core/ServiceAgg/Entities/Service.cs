using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }

        public int ServiceCategoryId { get; set; }
        public ServiceCategory ServiceCategory { get; set; }

        public ICollection<ServiceRequest> ServiceRequests { get; set; }
        public ICollection<ServiceImage> ServiceImages { get; set; }
    }
}
