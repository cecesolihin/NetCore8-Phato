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
            builder.ToTable(TableIdentity.GroupRoles);
            builder.HasKey(gr => new { gr.RoleId, gr.GroupId });

            builder.Property(gr => gr.RoleId).HasMaxLength(128).IsRequired();
            builder.Property(gr => gr.GroupId).HasMaxLength(128).IsRequired();
            builder.Property(gr => gr.InsertedBy).HasMaxLength(256);
            builder.Property(gr => gr.InsertedDate).IsRequired();
            builder.Property(gr => gr.ModifiedBy).HasMaxLength(256);
            builder.Property(gr => gr.ModifiedDate);
        }
    }
}
