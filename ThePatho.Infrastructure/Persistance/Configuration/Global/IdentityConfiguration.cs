using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class IdentityConfiguration : IEntityTypeConfiguration<Domain.Models.Global.Identity>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Global.Identity> builder)
        {
            builder.ToTable(TableGlobal.Identity);

            builder.HasKey(e => e.IdentityCode);
            builder.Property(e => e.IdentityCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.IdentityName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

