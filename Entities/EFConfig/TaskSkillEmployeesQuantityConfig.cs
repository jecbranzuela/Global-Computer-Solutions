using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCSClasses.EFClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCSClasses.EFConfig
{
    public class TaskSkillEmployeesQuantityConfig : IEntityTypeConfiguration<TaskSkillEmployeesQuantity>
    {
	    public void Configure(EntityTypeBuilder<TaskSkillEmployeesQuantity> builder)
	    {
			builder.ToTable("Task Skill Employees Quantity");
			builder.Property(c => c.TaskSkillEmployeesQuantityId).ValueGeneratedOnAdd();

			builder.HasOne(c => c.ProjectScheduleTaskLink)
			.WithMany(c => c.TaskSkillEmployeesQuantities)
			.HasForeignKey(c => c.ProjectScheduleTaskId)
			.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(c => c.TaskSkillLink)
			.WithMany(c => c.TaskSkillEmployeesQuantities)
			.HasForeignKey(c => c.TaskSkillId)
			.OnDelete(DeleteBehavior.Restrict);
	    }
    }
}
