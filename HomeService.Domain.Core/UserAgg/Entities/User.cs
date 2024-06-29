using HomeService.Domain.Core.PaymentAgg.Entities;
using HomeService.Domain.Core.ServiceAgg.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.UserAgg.Entities
{
    public class User : IdentityUser
    {
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string NationalCode { get; set; }

        #region Navigation Properties
        public ICollection<ServiceRequest> ServiceRequests { get; set; }
        public ICollection<ServiceSugesstion> ServiceSugesstions { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Review> ExpertReviews { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<ExpertSkill> ExpertSkills { get; set; }
        public ProfileImage ProfileImage { get; set; }
        # endregion
    }
}
