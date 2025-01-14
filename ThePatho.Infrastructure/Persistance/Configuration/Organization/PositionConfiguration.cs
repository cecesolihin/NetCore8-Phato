using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Domain.Models.Organization;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable(TableName.Position);

            builder.HasKey(e => e.PositionCode);

            builder.Property(e => e.PositionCode).HasColumnName("position_code").HasMaxLength(255).IsRequired();
            builder.Property(e => e.PositionName).HasColumnName("position_name").HasMaxLength(255).IsRequired();
            builder.Property(e => e.JobLevelCode).HasColumnName("job_level_code").HasMaxLength(50).IsRequired();
            builder.Property(e => e.OrgStructureId).HasColumnName("org_structure_id").IsRequired();
            builder.Property(e => e.ActAsHead).HasColumnName("act_as_head").IsRequired();
            builder.Property(e => e.Objective).HasColumnName("objective");
            builder.Property(e => e.JobDescription).HasColumnName("job_description");
            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted").IsRequired();
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");
        }
    }

}
