using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Organization;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class WorkLocationsConfiguration : IEntityTypeConfiguration<WorkLocation>
    {
        public void Configure(EntityTypeBuilder<WorkLocation> builder)
        {
            builder.ToTable(TableOrganization.WorkLocation);

            builder.HasKey(e => e.WorkLocationCode);
            builder.Property(e => e.WorkLocationCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.WorkLocationName).HasMaxLength(128).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
            builder.Property(e => e.Latitude).HasColumnType("decimal(18, 9)");
            builder.Property(e => e.Longitude).HasColumnType("decimal(18, 9)");
            builder.Property(e => e.Radius);
            builder.Property(e => e.IsActive);
            builder.Property(e => e.TimeZone).HasMaxLength(10);
            builder.Property(e => e.TaxLocationCode);
            builder.Property(e => e.HazardInformation);
        }
    }
}
