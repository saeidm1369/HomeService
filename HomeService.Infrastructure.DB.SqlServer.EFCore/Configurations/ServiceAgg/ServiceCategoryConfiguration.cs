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
    public class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasMany(sc => sc.Services)
                .WithOne(sc => sc.ServiceCategory)
                .HasForeignKey(sc => sc.ServiceCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
