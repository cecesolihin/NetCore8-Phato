using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Organization;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class EmploymentTypeConfiguration : IEntityTypeConfiguration<EmploymentType>
    {
        public void Configure(EntityTypeBuilder<EmploymentType> builder)
        {
            builder.ToTable(TableOrganization.EmploymentType);

            builder.HasKey(e => e.EmploymentTypeCode);
            builder.Property(e => e.EmploymentTypeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.EmploymentTypeName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.IsActive).IsRequired();
            builder.Property(e => e.SortOrder).IsRequired();
            builder.Property(e => e.Remarks).HasMaxLength(500);
            builder.Property(e => e.UseEndDate).IsRequired();
            builder.Property(e => e.EmploymentPeriodMonth);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
