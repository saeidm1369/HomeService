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
    public class ServiceRequestImageConfiguration : IEntityTypeConfiguration<ServiceRequestImage>
    {
        public void Configure(EntityTypeBuilder<ServiceRequestImage> builder)
        {
            builder.HasKey(sri => sri.Id);

            builder.Property(sri => sri.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(sri => sri.ServiceRequest)
                .WithMany(sr => sr.ServiceRequestImages)
                .HasForeignKey(sri => sri.ServiceRequestId);
        }
    }
}
