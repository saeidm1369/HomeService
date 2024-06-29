using HomeService.Domain.Core.PaymentAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Infrastructure.DB.SqlServer.EFCore.Configurations.PaymentAgg
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.InvoiceNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(i => i.InvoiceDate)
                .IsRequired();

            builder.Property(i => i.PaymentStatus)
                .IsRequired();

            builder.HasOne(i => i.PaymentStatus)
               .WithMany(ps => ps.Invoices)
               .HasForeignKey(i => i.PaymentStatusId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(i => i.InvoiceDetails)
                .WithOne(id => id.Invoice)
                .HasForeignKey(id => id.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Payment)
                .WithOne(i => i.Invoice)
                .HasForeignKey<Invoice>(id => id.PaymentId)
                .OnDelete(DeleteBehavior.Cascade);
                        

        }
    }
}
