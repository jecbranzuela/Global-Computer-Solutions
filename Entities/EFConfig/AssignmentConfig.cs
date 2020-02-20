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
    public class AssignmentConfig :IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.ToTable("Assignment");


            //optional relationship between assignment and employee, an can have zero or many assignments
            builder.HasOne(c => c.EmployeeLink)
                .WithMany(c => c.Assignments)
                .HasForeignKey(c => c.EmployeeId)
                .IsRequired(false);



        }
    }
}
