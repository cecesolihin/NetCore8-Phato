using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class GraduationTypeConfiguration : IEntityTypeConfiguration<GraduationType>
    {
        public void Configure(EntityTypeBuilder<GraduationType> builder)
        {
            builder.ToTable(TableGlobal.GraduationType);

            builder.HasKey(e => e.GradTypeCode);
            builder.Property(e => e.GradTypeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.GradTypeName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
