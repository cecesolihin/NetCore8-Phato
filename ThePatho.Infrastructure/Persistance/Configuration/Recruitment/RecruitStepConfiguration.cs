using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Domain.Models.Recruitment;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Recruitment
{
    public class RecruitStepConfiguration : IEntityTypeConfiguration<RecruitStep>
    {
        public void Configure(EntityTypeBuilder<RecruitStep> builder)
        {
            builder.ToTable(TableName.RecruitStep);

            builder.HasKey(e => e.RecruitStepCode);

            builder.Property(e => e.RecruitStepCode).HasColumnName("recruit_step_code").HasMaxLength(128).IsRequired();
            builder.Property(e => e.RecruitStepName).HasColumnName("recruit_step_name").HasColumnType("nvarchar(max)");
            builder.Property(e => e.UseFailedReason).HasColumnName("use_failed_reason").IsRequired();
            builder.Property(e => e.MinScore).HasColumnName("min_score").HasColumnType("decimal(9, 2)");
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");

        }
    }

}
