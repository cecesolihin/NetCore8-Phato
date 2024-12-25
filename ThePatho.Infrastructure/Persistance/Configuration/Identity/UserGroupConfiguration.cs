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
            builder.ToTable(TableName.UserGroups);
            builder.HasKey(e => e.UserGroupId);

            builder.Property(e => e.UserGroupId).HasColumnName("user_group_id").HasMaxLength(100).IsRequired();
            builder.Property(e => e.UserId).HasColumnName("user_id").HasMaxLength(100).IsRequired();
            builder.Property(e => e.GroupId).HasColumnName("group_id").HasMaxLength(50).IsRequired();
            builder.Property(e => e.IsActive).HasColumnName("is_active").HasDefaultValue(true).IsRequired();
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(50);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(50);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");
        }
    }
}
