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
    public class ProjectConfig :IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project");
            builder.Property(c => c.ProjectId).ValueGeneratedOnAdd();

            builder.HasOne(c => c.CustomerLink)
                .WithMany(c => c.Projects)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.EmployeeLink)
                .WithMany(c => c.Projects)
                .HasForeignKey(c => c.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
