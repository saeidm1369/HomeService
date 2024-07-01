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
    public class Paymentconfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(id => id.Id);
            builder.Property(a => a.Amount)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");
            builder.Property(pd => pd.PaymentDate)
                .IsRequired();
            builder.Property(t => t.TransactionId)
                .IsRequired();

            builder.HasOne(p => p.ServiceRequest)
                .WithMany(sr => sr.Payments)
                .HasForeignKey(p => p.ServiceRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.PaymentStatus)
                .WithMany(sr => sr.Payments)
                .HasForeignKey(p => p.PaymentStatusId)
                .OnDelete(DeleteBehavior.Restrict); 
                           
        }
    }
}
