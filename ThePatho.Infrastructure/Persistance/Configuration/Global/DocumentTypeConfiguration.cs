using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;
namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ToTable(TableGlobal.DocumentType);

            builder.HasKey(e => e.DocumentTypeCode);
            builder.Property(e => e.DocumentTypeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.DocumentTypeName);
            builder.Property(e => e.InsertedBy).HasMaxLength(256);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(256);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
