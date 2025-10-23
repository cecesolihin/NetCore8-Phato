using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeeCapColorConfiguration : IEntityTypeConfiguration<EmployeeCapColor>
    {
        public void Configure(EntityTypeBuilder<EmployeeCapColor> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeeCapColor);

            builder.HasKey(e => e.CapColorId);
            builder.Property(e => e.CapColorId).ValueGeneratedOnAdd();
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

