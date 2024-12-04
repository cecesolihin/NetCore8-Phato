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
    public class ScoringSettingConfiguration : IEntityTypeConfiguration<ScoringSetting>
    {
        public void Configure(EntityTypeBuilder<ScoringSetting> builder)
        {
            builder.ToTable(TableName.ScoringSetting);

            builder.HasKey(s => s.ScoringCode);

            builder.Property(s => s.ScoringCode).HasColumnName("scoring_code").HasMaxLength(128).IsRequired();
            builder.Property(s => s.MaxValue).HasColumnName("max_value").HasColumnType("decimal(18,2)");
            builder.Property(s => s.MinValue).HasColumnName("min_value").HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(s => s.NumericalType).HasColumnName("numerical_type");
            builder.Property(s => s.ScoringName).HasColumnName("scoring_name");
            builder.Property(s => s.ScoringType).HasColumnName("scoring_type").IsRequired();
            builder.Property(s => s.Remark).HasColumnName("remark");
            builder.Property(s => s.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255);
            builder.Property(s => s.InsertedDate).HasColumnName("inserted_date");
            builder.Property(s => s.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255);
            builder.Property(s => s.ModifiedDate).HasColumnName("modified_date");


            builder.HasMany(s => s.ScoringSettingDetails)
                   .WithOne(d => d.ScoringSetting)
                   .HasForeignKey(d => d.ScoringCode)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
