using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable(TableGlobal.Province);

            builder.HasKey(e => e.ProvinceId);
            builder.Property(e => e.ProvinceId).ValueGeneratedOnAdd();
            builder.Property(e => e.Abbreviation).HasMaxLength(20);
            builder.Property(e => e.CountryId).IsRequired();
            builder.Property(e => e.Sort);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
