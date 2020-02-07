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
    public class ProjectScheduleTaskConfig:IEntityTypeConfiguration<ProjectScheduleTask>
    {
        public void Configure(EntityTypeBuilder<ProjectScheduleTask> builder)
        {
            builder.ToTable("Project Schedule Task");
        }
    }
}
