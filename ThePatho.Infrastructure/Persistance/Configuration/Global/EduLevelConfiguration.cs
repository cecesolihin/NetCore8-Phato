using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class EduLevelConfiguration : IEntityTypeConfiguration<EduLevel>
    {
        public void Configure(EntityTypeBuilder<EduLevel> builder)
        {
            builder.ToTable(TableGlobal.EduLevel);

            builder.HasKey(e => e.EduLevelCode);
            builder.Property(e => e.EduLevelCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.EduLevelName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.Sort).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

