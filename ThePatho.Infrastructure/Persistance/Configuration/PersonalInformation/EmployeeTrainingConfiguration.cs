using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeeTrainingConfiguration : IEntityTypeConfiguration<EmployeeTraining>
    {
        public void Configure(EntityTypeBuilder<EmployeeTraining> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeeTraining);

            builder.HasKey(e => e.EmpTrainingId);

            builder.Property(e => e.EmpTrainingId)
                .HasColumnName("EmpTrainingId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.EmployeeID)
                .IsRequired();

            builder.Property(e => e.TrainingCourseCode)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(e => e.StartDate)
                .IsRequired();

            builder.Property(e => e.TrainingTypeCode)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(e => e.TrainingFieldCode)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(e => e.Institution)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Address)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.CityId)
                .IsRequired();

            builder.Property(e => e.CertificateNo)
                .HasMaxLength(100);

            builder.Property(e => e.CertificateDate);

            builder.Property(e => e.EndDate);

            builder.Property(e => e.TrainingPayerCode)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(e => e.CompanyBondDate);

            builder.Property(e => e.Remarks)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.IsDeleted)
                .IsRequired();

            builder.Property(e => e.InsertedBy)
                .HasMaxLength(255);

            builder.Property(e => e.InsertedDate);

            builder.Property(e => e.ModifiedBy)
                .HasMaxLength(255);

            builder.Property(e => e.ModifiedDate);

            builder.Property(e => e.TrainingBatchCode)
                .HasColumnType("nvarchar(max)");
        }
    }
}

