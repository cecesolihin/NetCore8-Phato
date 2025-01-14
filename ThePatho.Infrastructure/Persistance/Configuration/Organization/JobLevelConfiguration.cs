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
            builder.ToTable(TableName.JobLevel);

            builder.HasKey(e => e.JobLevelCode);

            builder.Property(e => e.JobLevelCode).HasColumnName("job_level_code").HasMaxLength(50).IsRequired();
            builder.Property(e => e.JobLevelName).HasColumnName("job_level_name").HasMaxLength(255).IsRequired();
            builder.Property(e => e.Jort).HasColumnName("jort");
            builder.Property(e => e.Remarks).HasColumnName("remarks").HasMaxLength(500);
            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted").IsRequired();
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");
            builder.Property(e => e.IsActive).HasColumnName("is_active");
        }
    }

}
