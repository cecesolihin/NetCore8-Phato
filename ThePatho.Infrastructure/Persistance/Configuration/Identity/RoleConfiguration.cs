using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Models.Identity;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Identity
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(TableIdentity.Roles);
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).HasMaxLength(128).IsRequired();
            builder.Property(r => r.Description).HasMaxLength(512);
            builder.Property(r => r.InsertedBy).HasMaxLength(256);
            builder.Property(r => r.InsertedDate).IsRequired();
            builder.Property(r => r.ModifiedBy).HasMaxLength(256);
            builder.Property(r => r.ModifiedDate);
            builder.Property(r => r.Name).HasMaxLength(256).IsRequired();
        }
    }
}
