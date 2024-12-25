using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Models.Applicant;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Applicant
{
    public class ApplicantEducationConfiguration : IEntityTypeConfiguration<ApplicantEducation>
    {
        public void Configure(EntityTypeBuilder<ApplicantEducation> builder)
        {
            builder.ToTable(TableName.ApplicantEducation);
            builder.HasKey(e => e.ApplicantNo);

            builder.Property(e => e.ApplicantNo).HasColumnName("applicant_no").HasMaxLength(128);
            builder.Property(e => e.EduLevelCode).HasColumnName("edu_level_code").HasMaxLength(128);
            builder.Property(e => e.MajorCode).HasColumnName("major_code").HasMaxLength(128);
            builder.Property(e => e.Faculty).HasColumnName("faculty").HasMaxLength(100);
            builder.Property(e => e.StartYear).HasColumnName("start_year");
            builder.Property(e => e.EndYear).HasColumnName("end_year");
            builder.Property(e => e.GPA).HasColumnName("gpa").HasMaxLength(50);
            builder.Property(e => e.MaxGPA).HasColumnName("max_gpa").HasMaxLength(50);
            builder.Property(e => e.Institution).HasColumnName("institution").HasMaxLength(100);
            builder.Property(e => e.Address).HasColumnName("address").HasMaxLength(500);
            builder.Property(e => e.CityCode).HasColumnName("city_code").HasMaxLength(50);
            builder.Property(e => e.GradTypeCode).HasColumnName("grad_type_code").HasMaxLength(128);
            builder.Property(e => e.CertificateNo).HasColumnName("certificate_no").HasMaxLength(50);
            builder.Property(e => e.CertificateDate).HasColumnName("certificate_date");
            builder.Property(e => e.Remark).HasColumnName("remark").HasMaxLength(500);
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by");
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");
        }
    }

}
