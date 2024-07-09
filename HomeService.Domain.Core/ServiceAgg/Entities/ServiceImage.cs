using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.Entities
{
    public class ServiceImage
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }

        public int ServiceId { get; set; }
        public Service? Service { get; set; }
    }
}
