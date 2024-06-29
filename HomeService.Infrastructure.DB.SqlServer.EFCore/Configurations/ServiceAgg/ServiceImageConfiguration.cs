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
    public class ServiceImageConfiguration : IEntityTypeConfiguration<ServiceImage>
    {
        public void Configure(EntityTypeBuilder<ServiceImage> builder)
        {
            builder.HasKey(si => si.Id);

            builder.Property(si => si.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(si => si.Service)
                .WithMany(si => si.ServiceImages)
                .HasForeignKey(si => si.ServiceId);
        }
    }
}
