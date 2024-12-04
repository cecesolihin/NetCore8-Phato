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
    public class ReasonStepFailedConfiguration : IEntityTypeConfiguration<ReasonStepFailed>
    {
        public void Configure(EntityTypeBuilder<ReasonStepFailed> builder)
        {
            builder.ToTable(TableName.ReasonStepFailed);
            // Composite Primary Key
            builder.HasKey(r => new { r.RecruitStepCode, r.ReasonCode });

            // Properties
            builder.Property(r => r.RecruitStepCode).HasColumnName("recruit_step_code").HasMaxLength(128).IsRequired();
            builder.Property(r => r.ReasonCode).HasColumnName("reason_code").HasMaxLength(128).IsRequired();
            builder.Property(r => r.ReasonName).HasColumnName("reason_name").HasMaxLength(255).IsRequired(false);
            builder.Property(r => r.Order).HasColumnName("order").HasColumnType("bit").IsRequired();
            builder.Property(r => r.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255).IsRequired(false);
            builder.Property(r => r.InsertedDate).HasColumnName("inserted_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(r => r.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255).IsRequired(false);
            builder.Property(r => r.ModifiedDate).HasColumnName("modified_date").HasColumnType("datetime").IsRequired(false);


        }
    }

}
