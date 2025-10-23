using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class TemplateKeywordConfiguration : IEntityTypeConfiguration<TemplateKeyword>
    {
        public void Configure(EntityTypeBuilder<TemplateKeyword> builder)
        {
            builder.ToTable(TableGlobal.TemplateKeyword);

            builder.HasKey(e => e.KeywordCode);
            builder.Property(e => e.KeywordCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.KeywordName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.StaticValue).IsRequired();
            builder.Property(e => e.Value);
            builder.Property(e => e.TableName).HasMaxLength(50);
            builder.Property(e => e.ColumnName).HasMaxLength(50);
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
