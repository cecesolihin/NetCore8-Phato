using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Models.Applicant;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Applicant
{
    public class ApplicantSkillConfiguration : IEntityTypeConfiguration<ApplicantSkill>
    {
        public void Configure(EntityTypeBuilder<ApplicantSkill> builder)
        {
            builder.ToTable(TableName.ApplicantSkill);
            // Composite Primary Key
            builder.HasKey(s => new { s.ApplicantNo, s.SkillCode });

            // Properties
            builder.Property(s => s.Description).HasColumnName("description").HasMaxLength(500);
            builder.Property(s => s.ProficiencyCode).HasColumnName("proficiency_code").HasMaxLength(50);
            builder.Property(s => s.Remarks).HasColumnName("remarks").HasMaxLength(500);
            builder.Property(s => s.InsertedBy).HasColumnName("inserted_by").HasMaxLength(50);
            builder.Property(s => s.ModifiedBy).HasColumnName("modified_by").HasMaxLength(50);


        }
    }

}
