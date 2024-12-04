using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Infrastructure.Persistance.Configuration.Recruitment
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ThePatho.Domain.Constants;
    using ThePatho.Domain.Models.Recruitment;

    public class RecruitmentRequestConfiguration : IEntityTypeConfiguration<RecruitmentRequest>
    {
        public void Configure(EntityTypeBuilder<RecruitmentRequest> builder)
        {
            builder.ToTable(TableName.RecruitmentRequest);
            builder.HasKey(r => r.RequestNo); // Primary key
            builder.Property(r => r.RequestNo).HasColumnName("request_no").HasMaxLength(128).IsRequired();
            builder.Property(r => r.RequestDate).HasColumnName("request_date").IsRequired(false);
            builder.Property(r => r.ApprovalStatus).HasColumnName("approval_status").IsRequired(false);
            builder.Property(r => r.RequestStatus).HasColumnName("request_status").IsRequired(false);
            builder.Property(r => r.ApprovedDate).HasColumnName("approved_date").IsRequired(false);
            builder.Property(r => r.RequestType).HasColumnName("request_type").HasMaxLength(50).IsRequired(false);
            builder.Property(r => r.MppPeriodCode).HasColumnName("mpp_period_code").HasMaxLength(128).IsRequired(false);
            builder.Property(r => r.MppNo).HasColumnName("mpp_no").HasMaxLength(128).IsRequired(false);
            builder.Property(r => r.OrganizationId).HasColumnName("organization_id").IsRequired(false);
            builder.Property(r => r.PositionCode).HasColumnName("position_code").HasMaxLength(255).IsRequired(false);
            builder.Property(r => r.JobClassCode).HasColumnName("job_class_code").HasMaxLength(128).IsRequired(false);
            builder.Property(r => r.JabatanId).HasColumnName("jabatan_id").IsRequired(false);
            builder.Property(r => r.JobLevelCode).HasColumnName("job_level_code").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(r => r.EmploymentTypeCode).HasColumnName("employment_type_code").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(r => r.UserEmpId).HasColumnName("user_emp_id").IsRequired(false);
            builder.Property(r => r.VacancyName).HasColumnName("vacancy_name").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(r => r.NumVacancyAll).HasColumnName("num_vacancy_all").IsRequired(false);
            builder.Property(r => r.NumVacancyMale).HasColumnName("num_vacancy_male").IsRequired(false);
            builder.Property(r => r.NumVacancyFemale).HasColumnName("num_vacancy_female").IsRequired(false);
            builder.Property(r => r.ExpectedJoinDate).HasColumnName("expected_join_date").IsRequired(false);
            builder.Property(r => r.JobCategoryId).HasColumnName("job_category_id").IsRequired(false);
            builder.Property(r => r.JobCategoryCode).HasColumnName("job_category_code").HasMaxLength(128).IsRequired(false);
            builder.Property(r => r.MinSalary).HasColumnName("min_salary").IsRequired(false);
            builder.Property(r => r.MaxSalary).HasColumnName("max_salary").IsRequired(false);
            builder.Property(r => r.RecStepGroupCode).HasColumnName("rec_step_group_code").HasMaxLength(128).IsRequired(false);
            builder.Property(r => r.AdsCode).HasColumnName("ads_code").HasMaxLength(128).IsRequired(false);
            builder.Property(r => r.StartAdvertDate).HasColumnName("start_advert_date").IsRequired(false);
            builder.Property(r => r.EndAdvertDate).HasColumnName("end_advert_date").IsRequired(false);
            builder.Property(r => r.VacancyType).HasColumnName("vacancy_type").HasMaxLength(50).IsRequired(false);
            builder.Property(r => r.CloseRemark).HasColumnName("close_remark").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(r => r.NoticeMonth).HasColumnName("notice_month").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(r => r.VacancyLink).HasColumnName("vacancy_link").HasMaxLength(225).IsRequired(false);
            builder.Property(r => r.QrLink).HasColumnName("qr_link").HasMaxLength(225).IsRequired(false);
            builder.Property(r => r.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255).IsRequired(false);
            builder.Property(r => r.InsertedDate).HasColumnName("inserted_date").IsRequired(false);
            builder.Property(r => r.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255).IsRequired(false);
            builder.Property(r => r.ModifiedDate).HasColumnName("modified_date").IsRequired(false);


        }
    }

}
