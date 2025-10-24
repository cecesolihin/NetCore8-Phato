using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeePickUpConfiguration : IEntityTypeConfiguration<EmployeePickUp>
    {
        public void Configure(EntityTypeBuilder<EmployeePickUp> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeePickUp);
            builder.HasKey(x => x.PickUpId);

            // Kolom-kolom
            builder.Property(x => x.PickUpId)
                .HasColumnType("tinyint")
                .IsRequired();

            builder.Property(x => x.PickUpLocation)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder.Property(x => x.InsertedBy)
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.InsertedDate)
                .HasColumnType("datetime");

            builder.Property(x => x.ModifiedBy)
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.ModifiedDate)
                .HasColumnType("datetime");
        }
    }
}

