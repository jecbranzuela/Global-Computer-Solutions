using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCSClasses.EFConfig
{
    public class TaskClassConfig:IEntityTypeConfiguration<GCSClasses.EFClasses.TaskClass>
    {
        public void Configure(EntityTypeBuilder<GCSClasses.EFClasses.TaskClass> builder)
        {
            builder.ToTable("Task");
            builder.Property(c => c.TaskClassId).ValueGeneratedOnAdd();

            //builder.HasIndex(c => c.Description).IsUnique();
        }
    }
}
