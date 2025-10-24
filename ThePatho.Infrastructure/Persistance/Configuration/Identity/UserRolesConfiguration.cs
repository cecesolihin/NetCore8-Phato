using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Identity;

namespace ThePatho.Infrastructure.Persistance.Configuration.Identity
{
    public class UserRolesConfiguration : IEntityTypeConfiguration<UserRoles>
    {
        public void Configure(EntityTypeBuilder<UserRoles> builder)
        {
            builder.ToTable(TableIdentity.UserRoles);
            builder.HasKey(ur => new { ur.UserId, ur.RoleId });
            // Kolom
            builder.Property(ur => ur.UserId)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(ur => ur.RoleId)
                .HasMaxLength(128)
                .IsRequired();

            //// Relasi ke User
            //builder.HasOne(ur => ur.User)
            //    .WithMany(u => u.UserRoles)
            //    .HasForeignKey(ur => ur.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //// Relasi ke Role
            //builder.HasOne(ur => ur.Role)
            //    .WithMany(r => r.UserRoles)
            //    .HasForeignKey(ur => ur.RoleId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
