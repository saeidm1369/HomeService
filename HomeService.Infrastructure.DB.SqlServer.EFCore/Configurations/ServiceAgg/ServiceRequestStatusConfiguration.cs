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
    public class ServiceRequestStatusConfiguration : IEntityTypeConfiguration<ServiceRequestStatus>
    {
        public void Configure(EntityTypeBuilder<ServiceRequestStatus> builder)
        {
            builder.HasKey(srs => srs.Id);

            builder.Property(srs => srs.Name)
                .IsRequired()
                .HasMaxLength(50);


            builder.HasMany(srs => srs.ServiceRequests)
                .WithOne(sr => sr.ServiceRequestStatus)
                .HasForeignKey(sr => sr.ServiceRequestStatusId);

            // تعریف داده‌های اولیه
            builder.HasData(
                new ServiceRequestStatus { Id = 1, Name = "Pending" },
                new ServiceRequestStatus { Id = 2, Name = "Accepted" },
                new ServiceRequestStatus { Id = 3, Name = "InProgress" },
                new ServiceRequestStatus { Id = 4, Name = "Completed" },
                new ServiceRequestStatus { Id = 5, Name = "Cancelled" }
            );
        }
    }
}
