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
    public class RecruitStepGroupConfiguration : IEntityTypeConfiguration<RecruitStepGroup>
    {
        public void Configure(EntityTypeBuilder<RecruitStepGroup> builder)
        {
            builder.ToTable(TableName.RecruitStepGroup);

            builder.HasKey(e => e.RecStepGroupCode);

            builder.Property(e => e.RecStepGroupCode).HasColumnName("rec_step_group_code").HasMaxLength(128).IsRequired();
            builder.Property(e => e.RecStepGroupName).HasColumnName("rec_step_group_name").HasMaxLength(255);
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");

        }
    }

}
