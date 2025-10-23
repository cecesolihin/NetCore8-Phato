using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Models.Identity;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Identity
{
    public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.ToTable(TableIdentity.UserGroups);
            builder.HasKey(ug => new { ug.UserId, ug.GroupId });

            builder.Property(ug => ug.UserId).HasMaxLength(128).IsRequired();
            builder.Property(ug => ug.GroupId).HasMaxLength(128).IsRequired();
            builder.Property(ug => ug.InsertedBy).HasMaxLength(256);
            builder.Property(ug => ug.InsertedDate).IsRequired();
            builder.Property(ug => ug.ModifiedBy).HasMaxLength(256);
            builder.Property(ug => ug.ModifiedDate);
        }
    }
}
