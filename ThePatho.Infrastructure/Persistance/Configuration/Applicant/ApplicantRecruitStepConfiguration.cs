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
    public class ApplicantRecruitStepConfiguration : IEntityTypeConfiguration<ApplicantRecruitStep>
    {
        public void Configure(EntityTypeBuilder<ApplicantRecruitStep> builder)
        {
            builder.ToTable(TableName.ApplicantRecruitStep);
            // Primary Key
            builder.HasKey(r => r.AppRecStepId);

            // Properties
            builder.Property(r => r.RecruitStepCode).HasColumnName("recruit_step_code").HasMaxLength(50).IsRequired();
            builder.Property(r => r.Score).HasColumnName("score").HasMaxLength(50);
            builder.Property(r => r.Notes).HasColumnName("notes").HasMaxLength(500);
            builder.Property(r => r.Attachment).HasColumnName("attachment").HasMaxLength(255);
            builder.Property(r => r.Status).HasColumnName("status").HasMaxLength(50);
            builder.Property(r => r.EmpScorer).HasColumnName("emp_scorer").IsRequired(false);
            builder.Property(r => r.ScheduleDate).HasColumnName("schedule_date").HasColumnType("datetime");
            builder.Property(r => r.ReasonCode).HasColumnName("reason_code").HasMaxLength(50);
            builder.Property(r => r.InsertedBy).HasColumnName("inserted_by").HasMaxLength(50);
            builder.Property(r => r.ModifiedBy).HasColumnName("modified_by").HasMaxLength(50);


        }
    }

}
