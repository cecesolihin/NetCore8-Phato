using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Models.Identity;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Identity
{
    public class GroupRoleConfiguration : IEntityTypeConfiguration<GroupRole>
    {
        public void Configure(EntityTypeBuilder<GroupRole> builder)
        {
            builder.ToTable(TableName.GroupRoles);
            builder.HasKey(e => e.GroupRoleId);

            builder.Property(e => e.GroupRoleId).HasColumnName("group_role_id").HasMaxLength(50).IsRequired();
            builder.Property(e => e.GroupId).HasColumnName("group_id").HasMaxLength(50).IsRequired();
            builder.Property(e => e.RoleId).HasColumnName("role_id").HasMaxLength(50);
            builder.Property(e => e.IsActive).HasColumnName("is_active").HasDefaultValue(true).IsRequired();
            builder.Property(e => e.ParentMenuId).HasColumnName("parent_menu_id");
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(50);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(50);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");
        }
    }
}
