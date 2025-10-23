using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;
namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class InsuranceConfiguration : IEntityTypeConfiguration<Insurance>
    {
        public void Configure(EntityTypeBuilder<Insurance> builder)
        {
            builder.ToTable(TableGlobal.Insurance);

            builder.HasKey(e => e.InsuranceCode);
            builder.Property(e => e.InsuranceCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.InsuranceName);
            builder.Property(e => e.InsertedBy).HasMaxLength(256);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(256);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
