using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class InventoryTypeConfiguration : IEntityTypeConfiguration<InventoryType>
    {
        public void Configure(EntityTypeBuilder<InventoryType> builder)
        {
            builder.ToTable(TableGlobal.InventoryType);

            builder.HasKey(e => e.InventoryTypeCode);
            builder.Property(e => e.InventoryTypeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.InventoryName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.InsertedBy);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
