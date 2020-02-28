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
    public class RegionConfig:IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Region");
            builder.HasKey(c => c.RegionId);
            builder.Property(c => c.RegionId).ValueGeneratedOnAdd();

            builder.HasIndex(c => c.Name).IsUnique();
            builder.Property(c => c.Name).IsRequired();


        }
    }
}
