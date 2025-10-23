using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;
namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class PunishmentTypeConfiguration : IEntityTypeConfiguration<PunishmentType>
    {
        public void Configure(EntityTypeBuilder<PunishmentType> builder)
        {
            builder.ToTable(TableGlobal.PunishmentType);

            builder.HasKey(e => e.PunishmentCode);
            builder.Property(e => e.PunishmentCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.PunishmentName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
