using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable(TableGlobal.Country);

            builder.HasKey(e => e.CountryId);
            builder.Property(e => e.CountryId).ValueGeneratedOnAdd();
            builder.Property(e => e.Sort);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Property(e => e.NumericIsoCode).IsRequired();
            builder.Property(e => e.ThreeLetterIsoCode).HasMaxLength(3);
            builder.Property(e => e.TwoLetterIsoCode).HasMaxLength(2);
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
