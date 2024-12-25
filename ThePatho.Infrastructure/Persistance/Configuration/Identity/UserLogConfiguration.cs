using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Models.Identity;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Identity
{
    public class UserLogConfiguration : IEntityTypeConfiguration<UserLog>
    {
        public void Configure(EntityTypeBuilder<UserLog> builder)
        {
            builder.ToTable(TableName.UserLogs);
            builder.HasKey(e => e.UserLogId);

            builder.Property(e => e.UserLogId).HasColumnName("user_log_id").HasMaxLength(50).IsRequired();
            builder.Property(e => e.Username).HasColumnName("username").HasMaxLength(100);
            builder.Property(e => e.UserId).HasColumnName("user_id").HasMaxLength(50);
            builder.Property(e => e.LoginLocationLongitude).HasColumnName("login_location_longitude");
            builder.Property(e => e.LoginLocationLatitude).HasColumnName("login_location_latitude");
            builder.Property(e => e.LoginTime).HasColumnName("login_time");
            builder.Property(e => e.StatusLog).HasColumnName("status_log").HasMaxLength(50);
            builder.Property(e => e.IsActive).HasColumnName("is_active").HasDefaultValue(true).IsRequired();
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(50);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(50);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");
        }
    }
}
