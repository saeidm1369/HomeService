using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<ExpertSkill>? ExpertSkills { get; set; }
    }
}
