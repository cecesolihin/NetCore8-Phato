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
            builder.ToTable(TableIdentity.Groups);
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id).HasMaxLength(128).IsRequired();
            builder.Property(g => g.Name);
            builder.Property(g => g.Description).HasMaxLength(512);
            builder.Property(g => g.InsertedBy).HasMaxLength(256);
            builder.Property(g => g.InsertedDate).IsRequired();
            builder.Property(g => g.ModifiedBy).HasMaxLength(256);
            builder.Property(g => g.ModifiedDate);
        }
    }
}
