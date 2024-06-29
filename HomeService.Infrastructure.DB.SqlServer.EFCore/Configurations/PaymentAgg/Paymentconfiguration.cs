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
                .IsRequired();
            builder.Property(pd => pd.PaymentDate)
                .IsRequired();
            builder.Property(t => t.TransactionId)
                .IsRequired();

            builder.HasOne(sr => sr.ServiceRequest)
                .WithMany(p => p.Payments)
                .HasForeignKey(id => id.ServiceRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ps => ps.PaymentStatus)
                .WithMany(p => p.Payments)
                .HasForeignKey(id => id.PaymentStatusId)
                .OnDelete(DeleteBehavior.Cascade); 
                           
        }
    }
}
