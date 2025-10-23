using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class RomanianSizeConfiguration : IEntityTypeConfiguration<RomanianSize>
    {
        public void Configure(EntityTypeBuilder<RomanianSize> builder)
        {
            builder.ToTable(TableGlobal.RomanianSize);

            builder.HasKey(e => e.RomanianSizeId);
            builder.Property(e => e.RomanianSizeId).ValueGeneratedOnAdd();
            builder.Property(e => e.RomanianSizeName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.InsertedBy);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
