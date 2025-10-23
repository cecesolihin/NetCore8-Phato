using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Organization;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class MutationTypeConfiguration : IEntityTypeConfiguration<MutationType>
    {
        public void Configure(EntityTypeBuilder<MutationType> builder)
        {
            builder.ToTable(TableOrganization.MutationType);

            builder.HasKey(e => e.MutationTypeCode);
            builder.Property(e => e.MutationTypeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.MutationTypeName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
