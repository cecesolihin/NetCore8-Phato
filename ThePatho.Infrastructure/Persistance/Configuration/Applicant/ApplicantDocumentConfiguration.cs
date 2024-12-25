using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Models.Applicant;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Applicant
{
    public class ApplicantDocumentConfiguration : IEntityTypeConfiguration<ApplicantDocument>
    {
        public void Configure(EntityTypeBuilder<ApplicantDocument> builder)
        {
            builder.ToTable(TableName.ApplicantDocument);
            builder.HasKey(e => e.ApplicantNo);

            builder.Property(e => e.ApplicantNo).HasColumnName("applicant_no").HasMaxLength(128);
            builder.Property(e => e.DocumentTypeCode).HasColumnName("document_type_code").HasMaxLength(128);
            builder.Property(e => e.FilePath).HasColumnName("file_path");
            builder.Property(e => e.Remark).HasColumnName("remark").HasMaxLength(500);
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by");
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");
        }
    }

}
