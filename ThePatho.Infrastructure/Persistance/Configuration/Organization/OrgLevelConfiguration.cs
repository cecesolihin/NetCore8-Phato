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
            builder.ToTable(TableOrganization.OrgLevel);

            builder.HasKey(e => e.OrgLevelCode);
            builder.Property(e => e.OrgLevelCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.OrgLevelName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.SortOrder).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }

}
