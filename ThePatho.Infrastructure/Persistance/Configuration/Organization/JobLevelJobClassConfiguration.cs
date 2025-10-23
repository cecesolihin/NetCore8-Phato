using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Organization;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class JobLevelJobClassConfiguration : IEntityTypeConfiguration<JobLevelJobClass>
    {
        public void Configure(EntityTypeBuilder<JobLevelJobClass> builder)
        {
            builder.ToTable(TableOrganization.JobLevelJobClass);

            builder.HasKey(e => new { e.JobLevelCode, e.JobClassCode });
            builder.Property(e => e.JobLevelCode).HasMaxLength(50).IsRequired();
            builder.Property(e => e.JobClassCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate).IsRequired();
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
