using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class RewardTypeConfiguration : IEntityTypeConfiguration<RewardType>
    {
        public void Configure(EntityTypeBuilder<RewardType> builder)
        {
            builder.ToTable(TableGlobal.RewardType);

            builder.HasKey(e => e.RewardTypeCode);
            builder.Property(e => e.RewardTypeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.RewardTypeName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
