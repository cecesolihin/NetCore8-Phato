using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeeFamilyConfiguration : IEntityTypeConfiguration<EmployeeFamily>
    {
        public void Configure(EntityTypeBuilder<EmployeeFamily> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeeFamily);

            builder.HasKey(e => e.EmployeeFamilyID);
            builder.Property(e => e.EmployeeFamilyID).ValueGeneratedOnAdd();
            builder.Property(e => e.EmployeeID).IsRequired();
            builder.Property(e => e.RelationCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.FamilyName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Gender).HasMaxLength(1).IsRequired();
            builder.Property(e => e.BirthPlace).HasMaxLength(100);
            builder.Property(e => e.BirthDate);
            builder.Property(e => e.Address);
            builder.Property(e => e.Phone).HasMaxLength(100);
            builder.Property(e => e.BloodTypeCode).HasMaxLength(128);
            builder.Property(e => e.EduLevelCode).HasMaxLength(128);
            builder.Property(e => e.MaritalStatusCode).HasMaxLength(128);
            builder.Property(e => e.DependentStatus).HasMaxLength(100).IsRequired();
            builder.Property(e => e.EmergencyContact).IsRequired();
            builder.Property(e => e.WorkingStatus);
            builder.Property(e => e.Company).HasMaxLength(100);
            builder.Property(e => e.Position).HasMaxLength(100);
            builder.Property(e => e.KKNo).HasMaxLength(100);
            builder.Property(e => e.IdentityNo).HasMaxLength(100);
            builder.Property(e => e.BPJSNo).HasMaxLength(100);
            builder.Property(e => e.InsuranceName).HasMaxLength(100);
            builder.Property(e => e.PolisNo).HasMaxLength(100);
            builder.Property(e => e.Remarks);
            builder.Property(e => e.VitalStatus);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

