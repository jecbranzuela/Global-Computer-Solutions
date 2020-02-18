using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCSClasses.EFConfig
{
    public class TaskConfig:IEntityTypeConfiguration<GCSClasses.EFClasses.Task>
    {
        public void Configure(EntityTypeBuilder<EFClasses.Task> builder)
        {
            builder.ToTable("Task");
            builder.Property(c => c.TaskId).ValueGeneratedOnAdd();

            builder.HasIndex(c => c.Description).IsUnique();
        }
    }
}
