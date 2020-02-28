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
    public class CustomerConfig:IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.Property(c => c.CustomerId).ValueGeneratedOnAdd();
            builder.Property(c => c.IsDeleted).HasDefaultValue(false);

            builder.HasOne(c => c.RegionLink)
                .WithMany(c => c.Customers)
                .HasForeignKey(c => c.RegionId);
        }
    }
}
