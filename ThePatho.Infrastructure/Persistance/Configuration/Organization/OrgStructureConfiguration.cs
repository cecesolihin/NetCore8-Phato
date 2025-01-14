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
    public class OrgStructureConfiguration : IEntityTypeConfiguration<OrgStructure>
    {
        public void Configure(EntityTypeBuilder<OrgStructure> builder)
        {
            builder.ToTable(TableName.OrgStructure);

            builder.HasKey(e => e.OrgStructureId);

            builder.Property(e => e.OrgStructureId).HasColumnName("org_structure_id").IsRequired();
            builder.Property(e => e.OrgStructureCode).HasColumnName("org_structure_code").HasMaxLength(50).IsRequired();
            builder.Property(e => e.OrgStructureName).HasColumnName("org_structure_name").HasMaxLength(255).IsRequired();
            builder.Property(e => e.ParentOrgId).HasColumnName("parent_org_id");
            builder.Property(e => e.OrgLevelCode).HasColumnName("org_level_code").HasMaxLength(128).IsRequired();
            builder.Property(e => e.Status).HasColumnName("status").IsRequired();
            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted").IsRequired();
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");
        }
    }

}
