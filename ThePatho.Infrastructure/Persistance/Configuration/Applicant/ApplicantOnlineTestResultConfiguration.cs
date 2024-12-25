using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Models.Applicant;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Applicant
{
    public class ApplicantOnlineTestResultConfiguration : IEntityTypeConfiguration<ApplicantOnlineTestResult>
    {
        public void Configure(EntityTypeBuilder<ApplicantOnlineTestResult> builder)
        {
            builder.ToTable(TableName.ApplicantOnlineTestResult);
            // Primary Key
            builder.HasKey(r => r.AppResultId);

            // Properties
            builder.Property(r => r.OnlineTestCode).HasColumnName("online_test_code").HasMaxLength(50).IsRequired();
            builder.Property(r => r.ApplicantNo).HasColumnName("applicant_no").HasMaxLength(50).IsRequired();
            builder.Property(r => r.QuestionnaireCode).HasColumnName("questionnaire_code").HasMaxLength(50);
            builder.Property(r => r.QuestionnaireName).HasColumnName("questionnaire_name").HasMaxLength(200);
            builder.Property(r => r.AnswerMethod).HasColumnName("answer_method").HasMaxLength(50);
            builder.Property(r => r.Remarks).HasColumnName("remarks").HasMaxLength(500);
            builder.Property(r => r.StartDate).HasColumnName("start_date").HasColumnType("datetime").IsRequired();
            builder.Property(r => r.EndDate).HasColumnName("end_date").HasColumnType("datetime");
            builder.Property(r => r.SubmitDate).HasColumnName("submit_date").HasColumnType("datetime");
            builder.Property(r => r.InsertedBy).HasColumnName("inserted_by").HasMaxLength(50);
            builder.Property(r => r.ModifiedBy).HasColumnName("modified_by").HasMaxLength(50);

        }
    }

}
