using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCSClasses.EFConfig
{
    public class SkillConfig : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skill");
            builder.HasKey(c => c.SkillId);
            builder.Property(c => c.SkillId).ValueGeneratedOnAdd();

            builder.HasIndex(c => c.Description).IsUnique();
            builder.Property(c => c.Description).IsRequired();
        }
    }
}
