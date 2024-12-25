using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Applicant;


namespace ThePatho.Infrastructure.Persistance.Configuration.Applicant
{
    public class ApplicantConfiguration : IEntityTypeConfiguration<ApplicantNew>
    {
        public void Configure(EntityTypeBuilder<ApplicantNew> builder)
        {
            builder.ToTable(TableName.Applicant);
            builder.HasKey(e => e.ApplicantNo);

            builder.Property(e => e.ApplicantNo).HasColumnName("applicant_no").HasMaxLength(128).IsRequired();
            builder.Property(e => e.FirstName).HasColumnName("first_name").HasMaxLength(100).IsRequired();
            builder.Property(e => e.MiddleName).HasColumnName("middle_name").HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.LastName).HasColumnName("last_name").HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.FullName).HasColumnName("full_name").HasMaxLength(100).IsRequired();
            builder.Property(e => e.Gender).HasColumnName("gender").HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.Blacklisted).HasColumnName("blacklisted").HasColumnType("bit").IsRequired();
            builder.Property(e => e.BlacklistRemarks).HasColumnName("blacklist_remarks").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(e => e.BirthPlace).HasColumnName("birth_place").HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.BirthDate).HasColumnName("birth_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255).IsRequired(false);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255).IsRequired(false);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.OrmasMembership).HasColumnName("ormas_membership").HasColumnType("bit").IsRequired(false);
            builder.Property(e => e.IsRehire).HasColumnName("is_rehire").HasColumnType("bit").IsRequired(false);
            builder.Property(e => e.HiredAsEmp).HasColumnName("hired_as_emp").HasColumnType("bit").IsRequired(false);

        }
    }
}
