using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;
namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class CareerTypeConfiguration : IEntityTypeConfiguration<CareerType>
    {
        public void Configure(EntityTypeBuilder<CareerType> builder)
        {
            builder.ToTable(TableGlobal.CareerType);

            builder.HasKey(e => e.CareerTypeCode);
            builder.Property(e => e.CareerTypeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.CareerTypeName);
            builder.Property(e => e.InsertedBy).HasMaxLength(256);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(256);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
