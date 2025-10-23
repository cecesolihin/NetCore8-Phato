using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;
namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class ShoeSizeConfiguration : IEntityTypeConfiguration<ShoeSize>
    {
        public void Configure(EntityTypeBuilder<ShoeSize> builder)
        {
            builder.ToTable(TableGlobal.ShoeSize);

            builder.HasKey(e => e.ShoeSizeCode);
            builder.Property(e => e.ShoeSizeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.ShoeSizeName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
