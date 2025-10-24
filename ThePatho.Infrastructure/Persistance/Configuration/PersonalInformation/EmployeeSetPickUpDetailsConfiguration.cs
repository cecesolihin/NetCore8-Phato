using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeeSetPickUpDetailsConfiguration : IEntityTypeConfiguration<EmployeeSetPickUpDetail>
    {
        public void Configure(EntityTypeBuilder<EmployeeSetPickUpDetail> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeeSetPickUpDetail);

            // Primary Key
            builder.HasKey(x => x.EmployeeSetPickUpDetailId);

            // Kolom-kolom
            builder.Property(x => x.EmployeeSetPickUpDetailId)
                .IsRequired();

            builder.Property(x => x.PickupID)
                .IsRequired();

            builder.Property(x => x.EmployeeId)
                .IsRequired();

            builder.Property(x => x.LocationCode)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.InsertedBy)
                .HasMaxLength(255);

            builder.Property(x => x.InsertedDate)
                .HasColumnType("datetime");

            builder.Property(x => x.ModifiedBy)
                .HasMaxLength(255);

            builder.Property(x => x.ModifiedDate)
                .HasColumnType("datetime");
        }
    }
}

