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
    public class ApplicantOnlineTestAnswerConfiguration : IEntityTypeConfiguration<ApplicantOnlineTestAnswer>
    {
        public void Configure(EntityTypeBuilder<ApplicantOnlineTestAnswer> builder)
        {
            builder.ToTable(TableName.ApplicantOnlineTestAnswer);
            // Primary Key
            builder.HasKey(a => a.AppAnswerId);

            builder.Property(a => a.AnswerValue).HasColumnName("answer_value").HasMaxLength(500);
            builder.Property(a => a.ScoringCode).HasColumnName("scoring_code").HasMaxLength(50);
            builder.Property(a => a.InsertedBy).HasColumnName("inserted_by").HasMaxLength(50);
            builder.Property(a => a.ModifiedBy).HasColumnName("modified_by").HasMaxLength(50);
            builder.Property(a => a.InsertedDate).HasColumnName("inserted_date").HasColumnType("datetime");
            builder.Property(a => a.ModifiedDate).HasColumnName("modified_date").HasColumnType("datetime");
            builder.Property(a => a.IsCorrect).HasColumnName("is_correct").HasColumnType("bit");

            // Foreign Key
            builder.HasOne(a => a.AppResult).WithMany(r => r.AppAnswers)
                .HasForeignKey(a => a.AppResultId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
