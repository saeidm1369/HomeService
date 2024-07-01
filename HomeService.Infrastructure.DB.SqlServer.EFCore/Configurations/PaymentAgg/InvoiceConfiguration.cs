using HomeService.Domain.Core.PaymentAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.HasOne(i => i.Payment)
                .WithMany(p => p.Invoices)
                .HasForeignKey(i => i.PaymentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.PaymentStatus)
                .WithMany(ps => ps.Invoices)
                .HasForeignKey(i => i.PaymentStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.User)
                .WithMany(u => u.Invoices)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(i => i.InvoiceDetails)
                .WithOne(id => id.Invoice)
                .HasForeignKey(id => id.InvoiceId);
        }
    }
}
