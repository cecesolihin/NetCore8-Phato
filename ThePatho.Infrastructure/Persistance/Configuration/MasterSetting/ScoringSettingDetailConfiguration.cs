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
    public class ScoringSettingDetailConfiguration : IEntityTypeConfiguration<ScoringSettingDetail>
    {
        public void Configure(EntityTypeBuilder<ScoringSettingDetail> builder)
        {
            builder.ToTable(TableName.ScoringSettingDetail);

            builder.HasKey(d => new { d.ScoringCode, d.Value, d.Character });

            builder.Property(d => d.ScoringCode).HasColumnName("scoring_code").HasMaxLength(128).IsRequired();
            builder.Property(d => d.Value).HasColumnName("value").HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(d => d.Character).HasColumnName("character").HasMaxLength(128).IsRequired();
            builder.Property(d => d.Attachment).HasColumnName("attachment").HasMaxLength(100);
            builder.Property(d => d.TextValue).HasColumnName("text_value").HasMaxLength(225);
            builder.Property(d => d.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255);
            builder.Property(d => d.InsertedDate).HasColumnName("inserted_date");
            builder.Property(d => d.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255);
            builder.Property(d => d.ModifiedDate).HasColumnName("modified_date");

        }
    }

}
