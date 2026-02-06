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
            builder.ToTable(TableOrganization.Position);

            builder.HasKey(e => e.PositionCode);
            builder.Property(e => e.PositionCode).HasMaxLength(255).IsRequired();
            builder.Property(e => e.PositionName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.JobLevelCode).HasMaxLength(50).IsRequired();
            builder.Property(e => e.OrgStructureID).IsRequired();
            builder.Property(e => e.ActAsHead).IsRequired();
            builder.Property(e => e.Objective);
            builder.Property(e => e.JobDescription);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
            builder.Property(e => e.StartDate);
            builder.Property(e => e.EndDate);
            builder.Property(e => e.DocumentNo);
            builder.Property(e => e.IsActive).IsRequired();
            builder.Property(e => e.ParentPositionCode).HasMaxLength(255);
            builder.Property(e => e.PositionPath);
        }
    }

}
