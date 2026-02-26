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
    public class TaxLocationConfiguration : IEntityTypeConfiguration<TaxLocation>
    {
        public void Configure(EntityTypeBuilder<TaxLocation> builder)
        {
            builder.ToTable(TableGlobal.TaxLocation);

            builder.HasKey(e => e.TaxLocationCode);

            builder.Property(e => e.TaxLocationCode)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.TaxLocationName)
                .HasMaxLength(100)
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
