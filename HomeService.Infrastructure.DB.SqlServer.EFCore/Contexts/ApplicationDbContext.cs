using HomeService.Domain.Core.PaymentAgg.Entities;
using HomeService.Domain.Core.ServiceAgg.Entities;
using HomeService.Domain.Core.UserAgg.Entities;
using HomeService.Infrastructure.DB.SqlServer.EFCore.Configurations.PaymentAgg;
using HomeService.Infrastructure.DB.SqlServer.EFCore.Configurations.ServiceAgg;
using HomeService.Infrastructure.DB.SqlServer.EFCore.Configurations.UserAgg;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Infrastructure.DB.SqlServer.EFCore.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)        
        {
        }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<ServiceSugesstion> ServiceSugesstions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ServiceRequestStatus> ServiceRequestStatuses { get; set; }
        public DbSet<ServiceImage> ServiceImages { get; set; }
        public DbSet<ServiceRequestImage> ServiceRequestImages { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ExpertSkill> ExpertSkills { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<ProfileImage> ProfileImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new ExpertSkillConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceDetailConfiguration());
            modelBuilder.ApplyConfiguration(new Paymentconfiguration());
            modelBuilder.ApplyConfiguration(new PaymentStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileImageConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceImageConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceRequestConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceRequestImageConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceRequestStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceSugesstionConfiguration());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}

