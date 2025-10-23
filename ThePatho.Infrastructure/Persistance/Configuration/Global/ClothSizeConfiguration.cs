using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class ClothSizeConfiguration : IEntityTypeConfiguration<ClothSize>
    {
        public void Configure(EntityTypeBuilder<ClothSize> builder)
        {
            builder.ToTable(TableGlobal.ClothSize);

            builder.HasKey(e => e.ClothSizeCode);
            builder.Property(e => e.ClothSizeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.ClothSizeName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
