using HomeService.Domain.Core.ServiceAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Infrastructure.DB.SqlServer.EFCore.Configurations.ServiceAgg
{
    public class ServiceRequestConfiguration : IEntityTypeConfiguration<ServiceRequest>
    {
        public void Configure(EntityTypeBuilder<ServiceRequest> builder)
        {
            builder.HasKey(sr => sr.Id);

            builder.Property(sr => sr.Description)
                .HasMaxLength(1000);

            builder.HasOne(sr => sr.Service)
                .WithMany(s => s.ServiceRequests)
                .HasForeignKey(sr => sr.ServiceId);

            builder.HasOne(sr => sr.ServiceRequestStatus)
                .WithMany(srs => srs.ServiceRequests)
                .HasForeignKey(sr => sr.ServiceRequestStatusId);

            builder.HasMany(sr => sr.ServiceSugesstions)
                .WithOne(sr => sr.ServiceRequest)
                .HasForeignKey(sr => sr.ServiceRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(sr => sr.ServiceRequestImages)
                .WithOne(sr => sr.ServiceRequest)
                .HasForeignKey(sr => sr.ServiceRequestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
