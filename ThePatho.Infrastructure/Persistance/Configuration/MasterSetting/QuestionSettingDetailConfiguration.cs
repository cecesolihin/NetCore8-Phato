using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Domain.Models.MasterSetting;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.MasterSetting
{
    public class QuestionSettingDetailConfiguration : IEntityTypeConfiguration<QuestionSettingDetail>
    {
        public void Configure(EntityTypeBuilder<QuestionSettingDetail> builder)
        {
            builder.ToTable(TableName.QuestionSettingDetail);

            builder.HasKey(e => e.QuestDetailId);

            builder.Property(e => e.QuestDetailId).HasColumnName("quest_detail_id").ValueGeneratedOnAdd();
            builder.Property(e => e.QuestionnaireCode).HasColumnName("questionnaire_code").HasMaxLength(50).IsRequired();
            builder.Property(e => e.IsCategory).HasColumnName("is_category").IsRequired();
            builder.Property(e => e.Question).HasColumnName("question");
            builder.Property(e => e.QuestParent).HasColumnName("quest_parent");
            builder.Property(e => e.ScoringCode).HasColumnName("scoring_code").HasMaxLength(128);
            builder.Property(e => e.Order).HasColumnName("order").IsRequired();
            builder.Property(e => e.Attachment).HasColumnName("attachment");
            builder.Property(e => e.MultiChoiceOption).HasColumnName("multi_choice_option");
            builder.Property(e => e.CorrectAnswer).HasColumnName("correct_answer");
            builder.Property(e => e.WeightPoint).HasColumnName("weight_point");
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");

        }
    }

}
