using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Organization;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class PensionTypeConfiguration : IEntityTypeConfiguration<PensionType>
    {
        public void Configure(EntityTypeBuilder<PensionType> builder)
        {
            builder.ToTable(TableOrganization.PensionType);

            builder.HasKey(e => e.PensionTypeCode);
            builder.Property(e => e.PensionTypeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.PensionTypeName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.InsertedBy);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
