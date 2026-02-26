

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class TimeZoneConfiguration : IEntityTypeConfiguration<ThePatho.Domain.Models.Global.TimeZone>
    {
        public void Configure(EntityTypeBuilder<ThePatho.Domain.Models.Global.TimeZone> builder)
        {
            builder.ToTable(TableGlobal.TimeZone);

            builder.HasKey(e => e.TimeZoneCode);

            builder.Property(e => e.TimeZoneCode)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.TimeZoneName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.IsDeleted)
                .IsRequired();

            builder.Property(e => e.InsertedBy)
                .HasMaxLength(50);

            builder.Property(e => e.InsertedDate);

            builder.Property(e => e.ModifiedBy)
                .HasMaxLength(50);

            builder.Property(e => e.ModifiedDate);
        }
    }
}
