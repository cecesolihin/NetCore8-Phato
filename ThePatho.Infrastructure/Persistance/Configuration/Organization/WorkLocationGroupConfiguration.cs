using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Organization;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class WorkLocationGroupConfiguration : IEntityTypeConfiguration<WorkLocationGroup>
    {
        public void Configure(EntityTypeBuilder<WorkLocationGroup> builder)
        {
            builder.ToTable(TableOrganization.WorkLocationGroup);

            builder.HasKey(e => e.GroupDetailId);
            builder.Property(e => e.GroupDetailId).ValueGeneratedOnAdd();
            builder.Property(e => e.GroupId).IsRequired();
            builder.Property(e => e.WorkLocationCode).HasMaxLength(128);
            builder.Property(e => e.InsertedBy);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
