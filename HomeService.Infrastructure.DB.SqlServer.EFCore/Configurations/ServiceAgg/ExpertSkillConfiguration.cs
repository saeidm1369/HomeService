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
    public class ExpertSkillConfiguration : IEntityTypeConfiguration<ExpertSkill>
    {
        public void Configure(EntityTypeBuilder<ExpertSkill> builder)
        {
            builder.HasKey(es => es.Id);
           
            builder.HasOne(es => es.User)
                .WithMany(es => es.ExpertSkills)
                .HasForeignKey(es => es.ExpertId)
                .OnDelete(DeleteBehavior.Restrict);

          
            builder.HasOne(es => es.Skill)
                .WithMany(es => es.ExpertSkills)
                .HasForeignKey(es => es.SkillId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
