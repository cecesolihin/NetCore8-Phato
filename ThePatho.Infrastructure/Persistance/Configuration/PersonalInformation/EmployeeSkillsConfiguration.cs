using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeeSkillsConfiguration : IEntityTypeConfiguration<EmployeeSkill>
    {
        public void Configure(EntityTypeBuilder<EmployeeSkill> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeeSkill);
            builder.HasKey(e => new { e.EmployeeID, e.SkillCode }); // composite key (karena tidak ada ID)

            builder.Property(e => e.EmployeeID)
                .IsRequired();

            builder.Property(e => e.SkillCode)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(e => e.ProfiencyCode)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(500);

            builder.Property(e => e.TakenDate);

            builder.Property(e => e.ExpiredDate);

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
        }
    }
}

