using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class InventoryGroupConfiguration : IEntityTypeConfiguration<InventoryGroup>
    {
        public void Configure(EntityTypeBuilder<InventoryGroup> builder)
        {
            builder.ToTable(TableGlobal.HInventoryGroup);
            builder.HasKey(x => x.InventoryGroupCode);

            // Kolom-kolom
            builder.Property(x => x.InventoryGroupCode)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.InventoryGroupName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.GroupBy)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.InsertedBy)
                .HasMaxLength(255);

            builder.Property(x => x.InsertedDate)
                .HasColumnType("datetime");

            builder.Property(x => x.ModifiedBy)
                .HasMaxLength(255);

            builder.Property(x => x.ModifiedDate)
                .HasColumnType("datetime");
        }
    }
}

