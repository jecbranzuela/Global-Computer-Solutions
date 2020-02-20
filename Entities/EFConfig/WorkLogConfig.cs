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
    public class WorkLogConfig:IEntityTypeConfiguration<WorkLog>
    {
        public void Configure(EntityTypeBuilder<WorkLog> builder)
        {
            builder.ToTable("Work Log");

            builder.HasOne(c => c.BillLink)
                .WithMany(c => c.WorkLogs)
                .HasForeignKey(c => c.BillId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
