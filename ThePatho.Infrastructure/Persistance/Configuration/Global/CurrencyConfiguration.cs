using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable(TableGlobal.Currency);

            builder.HasKey(e => e.CurrencyCode);
            builder.Property(e => e.CurrencyCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.CurrencyName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.Symbol).HasMaxLength(20).IsRequired();
            builder.Property(e => e.DecimalDigit).IsRequired();
            builder.Property(e => e.IsDefault).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
