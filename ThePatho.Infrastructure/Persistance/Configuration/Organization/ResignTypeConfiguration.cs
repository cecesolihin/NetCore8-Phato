using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Organization;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class ResignTypeConfiguration : IEntityTypeConfiguration<ResignType>
    {
        public void Configure(EntityTypeBuilder<ResignType> builder)
        {
            builder.ToTable(TableOrganization.ResignType);

            builder.HasKey(e => e.ResignTypeCode);
            builder.Property(e => e.ResignTypeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.ResignTypeName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
