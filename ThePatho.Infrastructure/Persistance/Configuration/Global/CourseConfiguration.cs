using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable(TableGlobal.Course);

            builder.HasKey(e => e.CourseCode);
            builder.Property(e => e.CourseCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.CourseName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.TrainingFieldCode).HasMaxLength(500);
            //builder.Property(e => e.Duration);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

