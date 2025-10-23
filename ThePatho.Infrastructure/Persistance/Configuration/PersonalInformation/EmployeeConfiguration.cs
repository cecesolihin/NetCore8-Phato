using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(TablePersonalInformation.Employee);

            builder.HasKey(e => e.EmployeeID);
            builder.Property(e => e.EmployeeID)
                   .ValueGeneratedOnAdd();

            // Employee Identification
            builder.Property(e => e.EmployeeNo)
                   .IsRequired(false);

            builder.Property(e => e.CompanyCode)
                   .HasMaxLength(128)
                   .IsRequired();

            // Personal Information
            builder.Property(e => e.Firstname)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.MiddleName)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(e => e.LastName)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(e => e.Fullname)
                   .HasMaxLength(300)
                   .IsRequired();

            builder.Property(e => e.Gender)
                   .IsRequired();

            builder.Property(e => e.BirthPlace)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(e => e.BirthDate)
                   .IsRequired();

            // Employment Information
            builder.Property(e => e.PositionCode)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(e => e.JoinDate)
                   .IsRequired();

            builder.Property(e => e.TerminateDate)
                   .IsRequired(false);

            builder.Property(e => e.PermanentDate)
                   .IsRequired(false);

            builder.Property(e => e.PensionDate)
                   .IsRequired(false);

            builder.Property(e => e.ContractEndDate)
                   .IsRequired(false);

            // Job Classification
            builder.Property(e => e.JobClassCode)
                   .HasMaxLength(128)
                   .IsRequired();

            builder.Property(e => e.EmploymentTypeCode)
                   .HasMaxLength(128)
                   .IsRequired();

            builder.Property(e => e.CostCenterCode)
                   .HasMaxLength(128)
                   .IsRequired();

            // Tax Information
            builder.Property(e => e.TaxType)
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(e => e.TaxStatusCode)
                   .HasMaxLength(128)
                   .IsRequired();

            builder.Property(e => e.NPWP)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(e => e.TaxLocationID)
                   .IsRequired(false);

            // Attendance and Identification
            builder.Property(e => e.AttendanceID)
                   .HasMaxLength(50)
                   .IsRequired(false);

            // Work Location
            builder.Property(e => e.WorkLocationCode)
                   .HasMaxLength(128)
                   .IsRequired(false);

            // BPJS Information
            builder.Property(e => e.BPJSTKLocation)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(e => e.BPJSKesLocation)
                   .HasMaxLength(50)
                   .IsRequired(false);

            // Additional References
            builder.Property(e => e.CapColorId)
                   .IsRequired(false);

            builder.Property(e => e.PickUpId)
                   .IsRequired(false);

            builder.Property(e => e.JabatanId)
                   .IsRequired(false);

            builder.Property(e => e.FaskesId)
                   .IsRequired(false);

            // Status Flags
            builder.Property(e => e.IsDeleted)
                   .IsRequired();

            builder.Property(e => e.NeedReplacement)
                   .IsRequired();

            builder.Property(e => e.IsEligibleRehire)
                   .IsRequired();

            // Audit Fields
            builder.Property(e => e.InsertedBy)
                   .IsRequired(false);

            builder.Property(e => e.InsertedDate)
                   .IsRequired(false);

            builder.Property(e => e.ModifiedBy)
                   .IsRequired(false);

            builder.Property(e => e.ModifiedDate)
                   .IsRequired(false);
        }
    }
}

