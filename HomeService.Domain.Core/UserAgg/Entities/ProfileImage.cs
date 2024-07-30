﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.UserAgg.Entities
{
    public class ProfileImage
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
