using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Models.MasterSetting;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.MasterSetting
{
    public class OnlineTestSettingConfiguration : IEntityTypeConfiguration<OnlineTestSetting>
    {
        public void Configure(EntityTypeBuilder<OnlineTestSetting> builder)
        {
            builder.ToTable(TableName.OnlineTestSetting);

            builder.HasKey(e => e.OnlineTestCode);

            builder.Property(e => e.OnlineTestCode).HasColumnName("online_test_code").HasMaxLength(128).IsRequired();
            builder.Property(e => e.OnlineTestName).HasColumnName("online_test_name").HasMaxLength(200);
            builder.Property(e => e.TestQuestion).HasColumnName("test_question").HasMaxLength(100).IsRequired();
            builder.Property(e => e.TestLocation).HasColumnName("test_location").HasMaxLength(200).IsRequired();
            builder.Property(e => e.Status).HasColumnName("status");
            builder.Property(e => e.RecruitmentReqNo).HasColumnName("recruitment_req_no").HasMaxLength(100);
            builder.Property(e => e.OnlineTestDateFrom).HasColumnName("online_test_date_from").IsRequired();
            builder.Property(e => e.OnlineTestDateTo).HasColumnName("online_test_date_to").IsRequired();
            builder.Property(e => e.OnlineTestTimeFrom).HasColumnName("online_test_time_from").IsRequired();
            builder.Property(e => e.OnlineTestTimeTo).HasColumnName("online_test_time_to").IsRequired();
            builder.Property(e => e.ScoringType).HasColumnName("scoring_type").HasMaxLength(100);
            builder.Property(e => e.EmailTemplate).HasColumnName("email_template").HasMaxLength(100);
            builder.Property(e => e.RecruitmentStep).HasColumnName("recruitment_step").HasMaxLength(100);
            builder.Property(e => e.MinScore).HasColumnName("min_score").IsRequired();
            builder.Property(e => e.Quota).HasColumnName("quota").IsRequired();
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");

        }
    }
}
