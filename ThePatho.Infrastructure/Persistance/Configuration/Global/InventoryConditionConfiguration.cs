using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class InventoryConditionConfiguration : IEntityTypeConfiguration<InventoryCondition>
    {
        public void Configure(EntityTypeBuilder<InventoryCondition> builder)
        {
            builder.ToTable(TableGlobal.InventoryCondition);

            builder.HasKey(e => e.InventoryConditionCode);
            builder.Property(e => e.InventoryConditionCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.InventoryConditionName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.InsertedBy);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
