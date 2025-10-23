using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class LetterTemplateConfiguration : IEntityTypeConfiguration<LetterTemplate>
    {
        public void Configure(EntityTypeBuilder<LetterTemplate> builder)
        {
            builder.ToTable(TableGlobal.LetterTemplate);

            builder.HasKey(e => e.LetterTemplateCode);
            builder.Property(e => e.LetterTemplateCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.LetterTemplateName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
