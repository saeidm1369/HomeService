using HomeService.Domain.Core.UserAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Infrastructure.DB.SqlServer.EFCore.Configurations.UserAgg
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.NationalCode)
                .IsRequired();
           
            builder.HasMany(u => u.ExpertSkills)
                .WithOne(es => es.User)
                .HasForeignKey(es => es.ExpertId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.ServiceRequests)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.ServiceSugesstions)
                .WithOne(u => u.Expert)
                .HasForeignKey(u => u.ExpertId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Reviews)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.ExpertReviews)
                .WithOne(u => u.Expert)
                .HasForeignKey(u => u.ExpertId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Payments)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Invoices)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

