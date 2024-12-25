using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Recruitment;

namespace ThePatho.Infrastructure.Persistance.Configuration.Recruitment
{
    public class RecruitmentReqStepConfiguration : IEntityTypeConfiguration<RecruitmentReqStep>
    {
        public void Configure(EntityTypeBuilder<RecruitmentReqStep> builder)
        {
            builder.ToTable(TableName.RecruitmentReqStep);
            builder.HasKey(r => r.RecruitReqStepId); // Primary key

            builder.Property(r => r.RequestNo).HasColumnName("request_no").HasMaxLength(128).IsRequired();
            builder.Property(r => r.RecruitStepCode).HasColumnName("recruit_step_code").HasMaxLength(128).IsRequired(false);
            builder.Property(r => r.ScheduleDate).HasColumnName("schedule_date").IsRequired();
            builder.Property(r => r.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255).IsRequired(false);
            builder.Property(r => r.InsertedDate).HasColumnName("inserted_date").IsRequired(false);
            builder.Property(r => r.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255).IsRequired(false);
            builder.Property(r => r.ModifiedDate).HasColumnName("modified_date").IsRequired(false);

        }
    }

}
