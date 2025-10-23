using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class TaxStatusConfiguration : IEntityTypeConfiguration<TaxStatus>
    {
        public void Configure(EntityTypeBuilder<TaxStatus> builder)
        {
            builder.ToTable(TableGlobal.TaxStatus);

            builder.ToTable(TableGlobal.TaxStatus);

            builder.HasKey(e => e.TaxStatusCode);

            builder.Property(e => e.TaxStatusCode)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(e => e.TaxStatusName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.Married)
                .IsRequired();

            builder.Property(e => e.TotalDependents)
                .IsRequired();

            builder.Property(e => e.IsDeleted)
                .IsRequired();

            builder.Property(e => e.InsertedBy);

            builder.Property(e => e.InsertedDate);

            builder.Property(e => e.ModifiedBy);

            builder.Property(e => e.ModifiedDate);
        }
    }
}
