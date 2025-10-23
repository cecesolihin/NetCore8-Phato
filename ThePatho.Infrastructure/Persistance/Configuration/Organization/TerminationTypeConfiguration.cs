using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Organization;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class TerminationTypeConfiguration : IEntityTypeConfiguration<TerminationType>
    {
        public void Configure(EntityTypeBuilder<TerminationType> builder)
        {
            builder.ToTable(TableOrganization.TerminationType);

            builder.HasKey(e => e.TerminationTypeCode);
            builder.Property(e => e.TerminationTypeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.TerminationTypeName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
