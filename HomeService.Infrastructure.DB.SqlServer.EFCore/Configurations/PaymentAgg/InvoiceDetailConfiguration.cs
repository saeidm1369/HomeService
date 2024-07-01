using HomeService.Domain.Core.PaymentAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Infrastructure.DB.SqlServer.EFCore.Configurations.PaymentAgg
{
    public class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(d => d.Description)
               .IsRequired()
               .HasMaxLength(500);
            builder.Property(a => a.Amount)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

        }
    }
}
