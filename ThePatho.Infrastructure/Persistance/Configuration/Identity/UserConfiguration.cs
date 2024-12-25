
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
            builder.ToTable(TableName.Users);
            builder.HasKey(e => e.UserId);
            builder.Property(e => e.Username).HasColumnName("username").HasMaxLength(100).IsRequired();
            builder.Property(e => e.FullName).HasColumnName("full_name").HasMaxLength(200);
            builder.Property(e => e.Email).HasColumnName("email").HasMaxLength(100).IsRequired();
            builder.Property(e => e.EmailConfirmed).HasColumnName("email_confirmed").IsRequired();
            builder.Property(e => e.PasswordHash).HasColumnName("password_hash").HasMaxLength(int.MaxValue);
            builder.Property(e => e.PhoneNumber).HasColumnName("phone_number").HasMaxLength(15);
            builder.Property(e => e.PhoneNumberConfirmed).HasColumnName("phone_number_confirmed").IsRequired();
            builder.Property(e => e.IsActive).HasColumnName("is_active").HasDefaultValue(true).IsRequired();
            builder.Property(e => e.IsLocked).HasColumnName("is_locked").HasDefaultValue(false).IsRequired();
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(50);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(50);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");
        }
    }
}
