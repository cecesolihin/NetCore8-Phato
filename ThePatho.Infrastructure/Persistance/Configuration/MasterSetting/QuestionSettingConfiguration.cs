using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Models.MasterSetting;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.MasterSetting
{
    public class QuestionSettingConfiguration : IEntityTypeConfiguration<QuestionSetting>
    {
        public void Configure(EntityTypeBuilder<QuestionSetting> builder)
        {
            builder.ToTable(TableName.QuestionSetting);

            builder.HasKey(e => e.QuestionnaireCode);

            builder.Property(e => e.QuestionnaireCode).HasColumnName("questionnaire_code").HasMaxLength(50).IsRequired();
            builder.Property(e => e.QuestionnaireName).HasColumnName("questionnaire_name").HasMaxLength(255).IsRequired();
            builder.Property(e => e.QuestionnaireType).HasColumnName("questionnaire_type").HasMaxLength(255).IsRequired();
            builder.Property(e => e.Remarks).HasColumnName("remarks");
            builder.Property(e => e.Active).HasColumnName("active").IsRequired();
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");
            builder.Property(e => e.AnswerMethod).HasColumnName("answer_method").HasMaxLength(255).IsRequired();
            builder.Property(e => e.RandomQuestion).HasColumnName("random_question").IsRequired();

        }
    }

}
