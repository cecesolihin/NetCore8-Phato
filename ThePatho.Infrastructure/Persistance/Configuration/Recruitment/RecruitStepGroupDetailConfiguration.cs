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
    public class RecruitStepGroupDetailConfiguration : IEntityTypeConfiguration<RecruitStepGroupDetail>
    {
        public void Configure(EntityTypeBuilder<RecruitStepGroupDetail> builder)
        {
            builder.ToTable(TableName.RecruitStepGroupDetail);

            builder.HasKey(e => e.RecStepGroupDetailId);

            builder.Property(e => e.RecStepGroupDetailId).HasColumnName("rec_step_group_detail_id").ValueGeneratedOnAdd();
            builder.Property(e => e.RecStepGroupCode).HasColumnName("rec_step_group_code").HasMaxLength(128).IsRequired();
            builder.Property(e => e.RecruitStepCode).HasColumnName("recruit_step_code").HasMaxLength(128).IsRequired();
            builder.Property(e => e.Order).HasColumnName("order").IsRequired();
            builder.Property(e => e.Duration).HasColumnName("duration");
            builder.Property(e => e.ProcessPass).HasColumnName("process_pass").HasMaxLength(50);
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");

        }
    }

}
