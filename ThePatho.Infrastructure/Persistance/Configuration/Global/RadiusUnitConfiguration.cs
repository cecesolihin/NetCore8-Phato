using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class RadiusUnitConfiguration : IEntityTypeConfiguration<RadiusUnit>
    {
        public void Configure(EntityTypeBuilder<RadiusUnit> builder)
        {
            builder.ToTable(TableGlobal.RadiusUnit);

            builder.HasKey(e => e.RadiusUnitCode);

            builder.Property(e => e.RadiusUnitCode)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.RadiusUnitName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.IsDeleted)
                .IsRequired();

            builder.Property(e => e.InsertedBy)
                .HasMaxLength(50);

            builder.Property(e => e.InsertedDate);

            builder.Property(e => e.ModifiedBy)
                .HasMaxLength(50);

            builder.Property(e => e.ModifiedDate);
        }
    }
}
