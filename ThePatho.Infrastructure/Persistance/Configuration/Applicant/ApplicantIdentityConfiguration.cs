using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Models.Applicant;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Applicant
{
    public class ApplicantIdentityConfiguration : IEntityTypeConfiguration<ApplicantIdentity>
    {
        public void Configure(EntityTypeBuilder<ApplicantIdentity> builder)
        {
            builder.ToTable(TableName.ApplicantIdentity);
            builder.HasKey(e => e.ApplicantNo);

            builder.Property(e => e.ApplicantNo).HasColumnName("applicant_no").HasMaxLength(128);
            builder.Property(e => e.IdentityCode).HasColumnName("identity_code").HasMaxLength(128);
            builder.Property(e => e.IdentityNo).HasColumnName("identity_no").HasMaxLength(50);
            builder.Property(e => e.IssuedDate).HasColumnName("issued_date");
            builder.Property(e => e.ExpiredDate).HasColumnName("expired_date");
            builder.Property(e => e.FileUpload).HasColumnName("file_upload");
            builder.Property(e => e.Remark).HasColumnName("remark").HasMaxLength(500);
            builder.Property(e => e.FileFullPath).HasColumnName("file_full_path");
            builder.Property(e => e.FileName).HasColumnName("file_name");
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by");
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");
        }
    }

}
