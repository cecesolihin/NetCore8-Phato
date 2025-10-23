using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeeDocumentsConfiguration : IEntityTypeConfiguration<EmployeeDocument>
    {
        public void Configure(EntityTypeBuilder<EmployeeDocument> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeeDocument);

            builder.HasKey(e => e.EmployeeDocumentId);
            builder.Property(e => e.EmployeeDocumentId).ValueGeneratedOnAdd();
            builder.Property(e => e.EmployeeID).IsRequired();
            builder.Property(e => e.DocumentTypeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.FilePath).IsRequired();
            builder.Property(e => e.Remark).HasMaxLength(500);
            builder.Property(e => e.InsertedBy);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

