
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Identity;

namespace ThePatho.Infrastructure.Persistance.Configuration.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(TableIdentity.Users);
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).HasMaxLength(128).IsRequired();
            builder.Property(u => u.FirstName).HasMaxLength(100);
            builder.Property(u => u.LastName).HasMaxLength(100);
            builder.Property(u => u.ProfilePicUrl).HasMaxLength(500);
            builder.Property(u => u.LastLoginTime);
            builder.Property(u => u.Activated).IsRequired();
            builder.Property(u => u.InsertedBy).HasMaxLength(256);
            builder.Property(u => u.InsertedDate).IsRequired();
            builder.Property(u => u.ModifiedBy).HasMaxLength(256);
            builder.Property(u => u.ModifiedDate);
            builder.Property(u => u.Email).HasMaxLength(250).IsRequired();
            builder.Property(u => u.EmailConfirmed).IsRequired();
            builder.Property(u => u.PasswordHash).HasMaxLength(512);
            builder.Property(u => u.SecurityStamp).HasMaxLength(512);
            builder.Property(u => u.PhoneNumber).HasMaxLength(32);
            builder.Property(u => u.PhoneNumberConfirmed).IsRequired();
            builder.Property(u => u.TwoFactorEnabled).IsRequired();
            builder.Property(u => u.LockoutEndDateUtc);
            builder.Property(u => u.LockoutEnabled).IsRequired();
            builder.Property(u => u.AccessFailedCount).IsRequired();
            builder.Property(u => u.UserName).HasMaxLength(256).IsRequired();
            builder.Property(u => u.EmpId);
            builder.Property(u => u.UserType).IsRequired();
            builder.Property(u => u.OtherIdentityId);
            builder.Property(u => u.PINHash);
        }
    }
}
