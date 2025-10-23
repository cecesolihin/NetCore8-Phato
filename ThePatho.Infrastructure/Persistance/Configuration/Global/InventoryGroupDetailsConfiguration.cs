using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class InventoryGroupDetailsConfiguration : IEntityTypeConfiguration<InventoryGroupDetail>
    {
        public void Configure(EntityTypeBuilder<InventoryGroupDetail> builder)
        {
            builder.ToTable(TableGlobal.DInventoryGroupDetail);

            builder.HasKey(e => e.InventoryGroupDetailId);
            builder.Property(e => e.InventoryGroupDetailId)
                   .ValueGeneratedOnAdd();

            // Foreign Key Fields
            builder.Property(e => e.InventoryGroupCode)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(e => e.InventoryTypeCode)
                   .HasMaxLength(128)
                   .IsRequired();

            // Audit Fields
            builder.Property(e => e.InsertedBy)
                   .HasMaxLength(255);

            builder.Property(e => e.InsertedDate);

            builder.Property(e => e.ModifiedBy)
                   .HasMaxLength(255);

            builder.Property(e => e.ModifiedDate);

        }
    }
}

