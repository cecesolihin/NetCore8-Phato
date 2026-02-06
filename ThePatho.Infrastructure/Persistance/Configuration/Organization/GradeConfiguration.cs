using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Organization;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.ToTable(TableOrganization.Grade);

            builder.HasKey(e => e.GradeCode);
            builder.Property(e => e.GradeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.GradeName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.SortOrder);
            builder.Property(e => e.IsActive).IsRequired();
            builder.Property(e => e.Remarks).HasMaxLength(500);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
