using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeeEducationsConfiguration : IEntityTypeConfiguration<EmployeeEducation>
    {
        public void Configure(EntityTypeBuilder<EmployeeEducation> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeeEducation);

            builder.HasKey(e => e.EmployeeEducationID);
            builder.Property(e => e.EmployeeEducationID).ValueGeneratedOnAdd();
            builder.Property(e => e.EmployeeID).IsRequired();
            builder.Property(e => e.EduLevelCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.Faculty).HasMaxLength(100);
            builder.Property(e => e.MajorCode).HasMaxLength(128);
            builder.Property(e => e.StartYear);
            builder.Property(e => e.EndYear);
            builder.Property(e => e.GPA).HasMaxLength(50);
            builder.Property(e => e.MaxGPA).HasMaxLength(50);
            builder.Property(e => e.Institution).HasMaxLength(100);
            builder.Property(e => e.Address);
            builder.Property(e => e.CityCode).HasMaxLength(100);
            builder.Property(e => e.GradTypeCode).HasMaxLength(128);
            builder.Property(e => e.CertificateNo).HasMaxLength(100);
            builder.Property(e => e.CertificateDate);
            builder.Property(e => e.Remarks);
            builder.Property(e => e.OtherMajor);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

