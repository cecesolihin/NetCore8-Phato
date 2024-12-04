using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Domain.Models.Applicant;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Applicant
{
    public class ApplicantWorkExperienceConfiguration : IEntityTypeConfiguration<ApplicantWorkExperience>
    {
        public void Configure(EntityTypeBuilder<ApplicantWorkExperience> builder)
        {
            // Primary Key
            builder.ToTable(TableName.ApplicantWorkExperience);
            builder.HasKey(w => w.AppWorkExpId);

            builder.Property(w => w.ApplicantNo).HasColumnName("applicant_no").HasMaxLength(50).IsRequired();
            builder.Property(w => w.StartWorking).HasColumnName("start_working").HasColumnType("datetime").IsRequired();
            builder.Property(w => w.EndWorking).HasColumnName("end_working").HasColumnType("datetime");
            builder.Property(w => w.Company).HasColumnName("company").HasMaxLength(255);
            builder.Property(w => w.BusinessField).HasColumnName("business_field").HasMaxLength(255);
            builder.Property(w => w.Address).HasColumnName("address").HasMaxLength(500);
            builder.Property(w => w.CityCode).HasColumnName("city_code").HasMaxLength(50);
            builder.Property(w => w.Phone).HasColumnName("phone").HasMaxLength(20);
            builder.Property(w => w.Website).HasColumnName("website").HasMaxLength(255);
            builder.Property(w => w.ResignReasonCode).HasColumnName("resign_reason_code").HasMaxLength(50);
            builder.Property(w => w.EmpTypeCode).HasColumnName("emp_type_code").HasMaxLength(50);
            builder.Property(w => w.Organization).HasColumnName("organization").HasMaxLength(100);
            builder.Property(w => w.JobLevel).HasColumnName("job_level").HasMaxLength(100);
            builder.Property(w => w.JobDesc).HasColumnName("job_desc").HasMaxLength(500);
            builder.Property(w => w.ReferenceName).HasColumnName("reference_name").HasMaxLength(100);
            builder.Property(w => w.ReferencePhone).HasColumnName("reference_phone").HasMaxLength(20);
            builder.Property(w => w.ReferenceEmail).HasColumnName("reference_email").HasMaxLength(100);
            builder.Property(w => w.Remark).HasColumnName("remark").HasMaxLength(500);
            builder.Property(w => w.IsLastWorkExperience).HasColumnName("is_last_work_experience").HasColumnType("bit");
            builder.Property(w => w.InsertedBy).HasColumnName("inserted_by").HasMaxLength(50);
            builder.Property(w => w.ModifiedBy).HasColumnName("modified_by").HasMaxLength(50);


        }
    }

}
