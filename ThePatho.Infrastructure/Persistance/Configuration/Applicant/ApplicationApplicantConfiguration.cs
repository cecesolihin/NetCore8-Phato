using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Models.Applicant;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Applicant
{
    public class ApplicationApplicantConfiguration : IEntityTypeConfiguration<ApplicationApplicant>
    {
        public void Configure(EntityTypeBuilder<ApplicationApplicant> builder)
        {
            builder.ToTable(TableName.ApplicationApplicant);
            // Primary Key
            builder.HasKey(a => a.RecApplicationId);

            // Properties
            builder.Property(a => a.RecApplicationId).HasColumnName("rec_application_id").IsRequired();
            builder.Property(a => a.ApplicantNo).HasColumnName("applicant_no").HasMaxLength(50).IsRequired();
            builder.Property(a => a.RequestNo).HasColumnName("request_no").HasMaxLength(50);
            builder.Property(a => a.AppliedDate).HasColumnName("applied_date").HasColumnType("datetime");
            builder.Property(a => a.AdsCode).HasColumnName("ads_code").HasMaxLength(50);
            builder.Property(a => a.RecruitmentFee).HasColumnName("recruitment_fee").HasMaxLength(50);
            builder.Property(a => a.Remarks).HasColumnName("remarks").HasMaxLength(500);
            builder.Property(a => a.MovedFrom).HasColumnName("moved_from").IsRequired(false);
            builder.Property(a => a.DateMoved).HasColumnName("date_moved").HasColumnType("datetime");
            builder.Property(a => a.Status).HasColumnName("status").HasMaxLength(50);
            builder.Property(a => a.EmployeeId).HasColumnName("employee_id").IsRequired(false);
            builder.Property(a => a.InsertedBy).HasColumnName("inserted_by").HasMaxLength(50);
            builder.Property(a => a.ModifiedBy).HasColumnName("modified_by").HasMaxLength(50);


        }
    }

}
