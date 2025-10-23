using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class DiseaseCategoryConfiguration : IEntityTypeConfiguration<DiseaseCategory>
    {
        public void Configure(EntityTypeBuilder<DiseaseCategory> builder)
        {
            builder.ToTable(TableGlobal.DiseaseCategory);

            builder.HasKey(e => e.DiseaseCategoryCode);
            builder.Property(e => e.DiseaseCategoryCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.DiseaseCategoryName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

