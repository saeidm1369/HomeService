using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.DTOs
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public ServiceCategoryDTO ServiceCategory { get; set; }
        public List<ServiceImageDTO> ServiceImages { get; set; }
    }
}
