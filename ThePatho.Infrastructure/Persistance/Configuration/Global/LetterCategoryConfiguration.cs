using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class LetterCategoryConfiguration : IEntityTypeConfiguration<LetterCategory>
    {
        public void Configure(EntityTypeBuilder<LetterCategory> builder)
        {
            builder.ToTable(TableGlobal.LetterCategory);

            builder.HasKey(e => e.LetterCategoryCode);
            builder.Property(e => e.LetterCategoryCode).HasMaxLength(200).IsRequired();
            builder.Property(e => e.LetterCategoryName).HasMaxLength(200);
            builder.Property(e => e.DocPattern).HasMaxLength(500);
            builder.Property(e => e.ResetType).HasMaxLength(10);
            builder.Property(e => e.MappingLetterTemplate);
            builder.Property(e => e.SequenceNo).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
