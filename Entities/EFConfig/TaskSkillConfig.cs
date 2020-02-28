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
    public class TaskSkillConfig:IEntityTypeConfiguration<TaskSkill>
    {
        public void Configure(EntityTypeBuilder<TaskSkill> builder)
        {
            builder.ToTable("Task Skill");
            builder.Property(c => c.TaskSkillId).ValueGeneratedOnAdd();
        }
    }
}
