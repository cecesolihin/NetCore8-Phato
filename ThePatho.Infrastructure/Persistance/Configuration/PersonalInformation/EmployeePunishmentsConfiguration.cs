using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeePunishmentsConfiguration : IEntityTypeConfiguration<EmployeePunishment>
    {
        public void Configure(EntityTypeBuilder<EmployeePunishment> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeePunishment);

            builder.HasKey(e => e.EmPunishmentID);
            builder.Property(e => e.EmPunishmentID).ValueGeneratedOnAdd();
            builder.Property(e => e.LetterNo).HasMaxLength(50).IsRequired();
            builder.Property(e => e.EmployeeID).IsRequired();
            builder.Property(e => e.LetterDate).IsRequired();
            builder.Property(e => e.PunishmentType).HasMaxLength(50).IsRequired();
            builder.Property(e => e.ValidFrom).IsRequired();
            builder.Property(e => e.ValidTo).IsRequired();
            builder.Property(e => e.RecoveryDate);
            builder.Property(e => e.Remarks);
            builder.Property(e => e.Attachment);
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

