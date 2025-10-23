using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeeWorkingExperienceConfiguration : IEntityTypeConfiguration<EmployeeWorkingExperience>
    {
        public void Configure(EntityTypeBuilder<EmployeeWorkingExperience> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeeWorkingExperience);

            builder.HasKey(e => e.EmpWorkExperienceId );

            builder.Property(e => e.EmployeeID)
                .IsRequired();

            builder.Property(e => e.StartWorking)
                .IsRequired();

            builder.Property(e => e.EndWorking);

            builder.Property(e => e.EmploymentTypeCode)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(e => e.Organization)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(e => e.Company)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.BusinessField)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Address)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.CityId);

            builder.Property(e => e.JobLevel)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.JobDescription)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Phone)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.Website)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.ReferenceName)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.ReferencePhone)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.ReferenceEmail)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.CurrencyCode21)
                .HasMaxLength(128);

            builder.Property(e => e.CurrencyCode15)
                .HasMaxLength(128);

            builder.Property(e => e.PphA21)
                .HasColumnType("float");

            builder.Property(e => e.PphA15)
                .HasColumnType("float");

            builder.Property(e => e.Remarks)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.IsDeleted)
                .IsRequired();

            builder.Property(e => e.InsertedBy)
                .HasMaxLength(255);

            builder.Property(e => e.InsertedDate)
                .HasColumnType("datetime");

            builder.Property(e => e.ModifiedBy)
                .HasMaxLength(255);

            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime");

            builder.Property(e => e.ResignReason)
                .HasColumnType("nvarchar(max)");
        }
    }
}

