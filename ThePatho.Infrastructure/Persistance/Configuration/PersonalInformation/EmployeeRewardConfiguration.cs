using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeeRewardConfiguration : IEntityTypeConfiguration<EmployeeReward>
    {
        public void Configure(EntityTypeBuilder<EmployeeReward> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeeReward);

            builder.HasKey(e => e.EmRewardID);
            builder.Property(e => e.EmRewardID).ValueGeneratedOnAdd();
            builder.Property(e => e.LetterNo).HasMaxLength(50).IsRequired();
            builder.Property(e => e.EmployeeID).IsRequired();
            builder.Property(e => e.LetterDate).IsRequired();
            builder.Property(e => e.RewardTypeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.Remarks);
            builder.Property(e => e.CurrencyCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.Amount).HasColumnType("decimal(18,2)");
            builder.Property(e => e.Attachment);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

