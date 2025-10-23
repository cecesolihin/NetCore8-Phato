using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeeCareerHistoryConfiguration : IEntityTypeConfiguration<EmployeeCareerHistory>
    {
        public void Configure(EntityTypeBuilder<EmployeeCareerHistory> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeeCareerHistory);

            builder.HasKey(e => e.CareerHistoryNo);
            builder.Property(e => e.CareerHistoryNo).HasMaxLength(50).IsRequired();

            // Basic Employee Information
            builder.Property(e => e.EmployeeID).IsRequired();
            builder.Property(e => e.EmployeeNo).HasMaxLength(50);
            builder.Property(e => e.CompanyCode).HasMaxLength(128).IsRequired();

            // Employment Details
            builder.Property(e => e.EmploymentTypeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.ChangeType).HasMaxLength(50);

            // Position and Structure
            builder.Property(e => e.PositionCode).HasMaxLength(255).IsRequired();
            builder.Property(e => e.OrgStructureId).IsRequired();
            builder.Property(e => e.JobLevelCode).HasMaxLength(50).IsRequired();
            builder.Property(e => e.JobClassCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.GradeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.RankCode).HasMaxLength(50).IsRequired();
            builder.Property(e => e.CostCenterCode).HasMaxLength(50).IsRequired();

            // Date Information
            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e => e.EndDate);
            builder.Property(e => e.EffectiveDateTo);
            builder.Property(e => e.JoinDate);

            // Additional Information
            builder.Property(e => e.Remark).HasMaxLength(500);
            builder.Property(e => e.WorkLocationCode).HasMaxLength(128);
            builder.Property(e => e.ResignTypeCode).HasMaxLength(128);
            builder.Property(e => e.TerminationTypeCode).HasMaxLength(128);
            builder.Property(e => e.PensionTypeCode).HasMaxLength(128);
            builder.Property(e => e.MutationTypeCode).HasMaxLength(128);

            // Location and Assignment
            builder.Property(e => e.AssignmentLocation).HasMaxLength(255);
            builder.Property(e => e.TaxLocationID);

            // Flags and Status
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.IsIncludeSalary).IsRequired();
            builder.Property(e => e.UsePayrollData).IsRequired();
            builder.Property(e => e.UseOldJoinDate);
            builder.Property(e => e.IsEligibleRehire).IsRequired();

            // References and Relationships
            builder.Property(e => e.EmpSalCompId).IsRequired();
            builder.Property(e => e.OldEmployeeId);
            builder.Property(e => e.JabatanId);

            // Path for hierarchical data
            builder.Property(e => e.Path).HasMaxLength(500);

            // Audit Fields
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

