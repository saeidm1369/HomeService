using HomeService.Domain.Core.UserAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.DTOs
{
    public class ExpertSkillDTO
    {
        public int Id { get; set; }
        public string ExpertId { get; set; }
        public UserDTO Expert { get; set; }
        public int SkillId { get; set; }
        public SkillDTO Skill { get; set; }
    }
}
