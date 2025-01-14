using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Models.Organization;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class OrgLevelConfiguration : IEntityTypeConfiguration<OrgLevel>
    {
        public void Configure(EntityTypeBuilder<OrgLevel> builder)
        {
            builder.ToTable(TableName.OrganizationLevel);

            builder.HasKey(e => e.OrgLevelCode);

            builder.Property(e => e.OrgLevelCode).HasColumnName("org_level_code").HasMaxLength(128).IsRequired();
            builder.Property(e => e.OrgLevelName).HasColumnName("org_level_name").HasMaxLength(255).IsRequired();
            builder.Property(e => e.Sort).HasColumnName("sort").IsRequired();
            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted").IsRequired();
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");
        }
    }

}
