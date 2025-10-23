using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class NumericalSizeConfiguration : IEntityTypeConfiguration<NumericalSize>
    {
        public void Configure(EntityTypeBuilder<NumericalSize> builder)
        {
            builder.ToTable(TableGlobal.NumericalSize);

            builder.HasKey(e => e.NumericalSizeId);
            builder.Property(e => e.NumericalSizeId).ValueGeneratedOnAdd();
            builder.Property(e => e.NumericalSizeName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.InsertedBy);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
