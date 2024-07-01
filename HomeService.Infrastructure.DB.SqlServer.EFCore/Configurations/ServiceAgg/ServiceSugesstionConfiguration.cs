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
    public class ServiceSugesstionConfiguration : IEntityTypeConfiguration<ServiceSugesstion>
    {
        public void Configure(EntityTypeBuilder<ServiceSugesstion> builder)
        {
            builder.HasKey(ss => ss.Id);

            builder.Property(ss => ss.ServiceSugesstionDate)
                .IsRequired();

            builder.Property(ss => ss.ServiceSugesstionPrice)
            .IsRequired()
            .HasColumnType("decimal(18, 2)");


            builder.HasOne(ss => ss.ServiceRequest)
                .WithMany(sr => sr.ServiceSugesstions)
                .HasForeignKey(ss => ss.ServiceRequestId);
        }
    }
}
