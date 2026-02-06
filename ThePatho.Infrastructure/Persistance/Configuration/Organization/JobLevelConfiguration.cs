using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Models.Organization;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class JobLevelConfiguration : IEntityTypeConfiguration<JobLevel>
    {
        public void Configure(EntityTypeBuilder<JobLevel> builder)
        {
            builder.ToTable(TableOrganization.JobLevel);

            builder.HasKey(e => e.JobLevelCode);
            builder.Property(e => e.JobLevelCode).HasMaxLength(50).IsRequired();
            builder.Property(e => e.JobLevelName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.SortOrder);
            builder.Property(e => e.Remarks).HasMaxLength(500);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
            builder.Property(e => e.IsActive);
        }
    }

}
