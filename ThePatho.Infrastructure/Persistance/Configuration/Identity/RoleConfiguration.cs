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
            builder.ToTable(TableName.Roles);
            builder.HasKey(e => e.RoleId);

            builder.Property(e => e.RoleId).HasColumnName("role_id").HasMaxLength(50).IsRequired();
            builder.Property(e => e.RoleName).HasColumnName("role_name").HasMaxLength(255).IsRequired();
            builder.Property(e => e.Description).HasColumnName("description").HasMaxLength(255);
            builder.Property(e => e.ParentMenuId).HasColumnName("parent_menu_id");
            builder.Property(e => e.RoleLabel).HasColumnName("role_label").HasMaxLength(255);
            builder.Property(e => e.OrderNo).HasColumnName("order_no");
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(50);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(50);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");
        }
    }
}
