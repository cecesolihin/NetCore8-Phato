using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Identity;

namespace ThePatho.Infrastructure.Persistance.Configuration.Identity
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable(TableName.Groups);
            builder.HasKey(e => e.GroupId);

            builder.Property(e => e.GroupId).HasColumnName("group_id").HasMaxLength(50).IsRequired();
            builder.Property(e => e.GroupName).HasColumnName("group_name").HasMaxLength(255);
            builder.Property(e => e.Description).HasColumnName("description").HasMaxLength(255);
            builder.Property(e => e.IsActive).HasColumnName("is_active").HasDefaultValue(true).IsRequired();
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(50);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(50);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");
        }
    }
}
