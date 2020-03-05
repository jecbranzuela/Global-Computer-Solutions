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
            builder.Property(c => c.IsDeleted).HasDefaultValue(false);

            //pwede dili sa ibutang sa pag create sa project, pwede at a later date na ibutang
            builder.Property(c => c.ActualEndDate).IsRequired(false);
            builder.Property(c => c.ActualStartDate).IsRequired(false);
            builder.Property(c => c.ActualCost).IsRequired(false);

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
