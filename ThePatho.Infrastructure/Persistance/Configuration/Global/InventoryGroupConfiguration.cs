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
        }
    }
}

