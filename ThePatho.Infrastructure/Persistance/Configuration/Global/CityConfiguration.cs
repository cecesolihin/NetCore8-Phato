using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable(TableGlobal.City);

            builder.HasKey(e => e.CityId);
            builder.Property(e => e.CityId).ValueGeneratedOnAdd();
            builder.Property(e => e.CityCode).HasMaxLength(20).IsRequired();
            builder.Property(e => e.ProvinceId).IsRequired();
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
