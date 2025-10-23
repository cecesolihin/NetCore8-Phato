using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class InventoryGroupOrgConfiguration : IEntityTypeConfiguration<InventoryGroupOrg>
    {
        public void Configure(EntityTypeBuilder<InventoryGroupOrg> builder)
        {
            builder.ToTable(TableGlobal.DInventoryGroupOrg);
            builder.HasKey(e => e.InventoryGroupOrgId);
            builder.Property(e => e.InventoryGroupOrgId).ValueGeneratedOnAdd();
            builder.Property(e => e.InventoryGroupCode).IsRequired();
            builder.Property(e => e.OrganizationCode);
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

