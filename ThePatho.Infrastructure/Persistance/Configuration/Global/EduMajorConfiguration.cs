using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class EduMajorConfiguration : IEntityTypeConfiguration<EduMajor>
    {
        public void Configure(EntityTypeBuilder<EduMajor> builder)
        {
            builder.ToTable(TableGlobal.EduMajor);
            builder.HasKey(e => e.MajorCode);
            builder.Property(e => e.MajorCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.MajorName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

