using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Organization;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class JobClassConfiguration : IEntityTypeConfiguration<JobClass>
    {
        public void Configure(EntityTypeBuilder<JobClass> builder)
        {
            builder.ToTable(TableOrganization.JobClass);

            builder.HasKey(e => e.JobClassCode);
            builder.Property(e => e.JobClassCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.JobClassName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.GradeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.RankCode).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Remarks).HasMaxLength(255);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
            builder.Property(e => e.IsActive);
        }
    }
}
