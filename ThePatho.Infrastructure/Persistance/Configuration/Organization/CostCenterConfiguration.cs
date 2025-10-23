using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Organization;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class CostCenterConfiguration : IEntityTypeConfiguration<CostCenter>
    {
        public void Configure(EntityTypeBuilder<CostCenter> builder)
        {
            builder.ToTable(TableOrganization.CostCenter);

            builder.HasKey(e => e.CostCenterCode);

            builder.Property(e => e.CostCenterCode)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(e => e.CostCenterName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.Sort)
                .IsRequired();

            builder.Property(e => e.IsDeleted)
                .IsRequired();

            builder.Property(e => e.InsertedBy)
                .HasMaxLength(255);

            builder.Property(e => e.InsertedDate);

            builder.Property(e => e.ModifiedBy)
                .HasMaxLength(255);

            builder.Property(e => e.ModifiedDate);

            builder.Property(e => e.CostCenterType)
                .HasMaxLength(128);
        }
    }
}
