using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeeSetPickUpConfiguration : IEntityTypeConfiguration<EmployeeSetPickUp>
    {
        public void Configure(EntityTypeBuilder<EmployeeSetPickUp> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeeSetPickUp);

            builder.HasKey(e => e.PickupID);
            builder.Property(e => e.PickupID).IsRequired();
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.PickUpType).HasMaxLength(250).IsRequired();
            builder.Property(e => e.RouteCode).HasMaxLength(50).IsRequired();
            builder.Property(e => e.PlanOut).IsRequired();
            builder.Property(e => e.ToleranceBefore).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(e => e.ToleranceAfter).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(e => e.DepartTime).IsRequired();
            builder.Property(e => e.ArriveTime).IsRequired();
            builder.Property(e => e.TotalEmployee).IsRequired();
            builder.Property(e => e.Capacity).IsRequired();
            builder.Property(e => e.BusCode);
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

