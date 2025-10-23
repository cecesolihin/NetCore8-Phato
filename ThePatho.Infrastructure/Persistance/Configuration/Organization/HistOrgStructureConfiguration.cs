using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Organization;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class HistOrgStructureConfiguration : IEntityTypeConfiguration<HistOrgStructure>
    {
        public void Configure(EntityTypeBuilder<HistOrgStructure> builder)
        {
            builder.ToTable(TableOrganization.HistOrgStructure);

            builder.HasKey(e => e.HistOrgStructureID);
            builder.Property(e => e.HistOrgStructureID).ValueGeneratedOnAdd();
            builder.Property(e => e.OrgStructureID).IsRequired();
            builder.Property(e => e.OrgStructureCode).HasMaxLength(50).IsRequired();
            builder.Property(e => e.OrgStructureName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.ParentOrgStructureID);
            builder.Property(e => e.OrgLevelCode).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Status).HasMaxLength(1).IsRequired();
            builder.Property(e => e.CostCenterCode).HasMaxLength(50);
            builder.Property(e => e.Location).HasMaxLength(255);
            builder.Property(e => e.Phone).HasMaxLength(50);
            builder.Property(e => e.PhoneExt).HasMaxLength(10);
            builder.Property(e => e.Sort).IsRequired();
            builder.Property(e => e.CompanyCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.StartDate);
            builder.Property(e => e.EndDate);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.Path).HasMaxLength(200);
            builder.Property(e => e.Function).HasMaxLength(255);
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
