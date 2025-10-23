using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeeAddressConfiguration : IEntityTypeConfiguration<EmployeeAddress>
    {
        public void Configure(EntityTypeBuilder<EmployeeAddress> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeeAddress);
            builder.HasKey(e => new { e.EmployeeID, e.CompanyCode });

            builder.Property(e => e.EmployeeID).IsRequired();
            builder.Property(e => e.CompanyCode).HasMaxLength(128).IsRequired();

            // Alamat KTP
            builder.Property(e => e.Address).HasMaxLength(500).IsRequired();
            builder.Property(e => e.RT).HasMaxLength(10);
            builder.Property(e => e.RW).HasMaxLength(10);
            builder.Property(e => e.SubDistrict).HasMaxLength(100);
            builder.Property(e => e.District).HasMaxLength(100);
            builder.Property(e => e.CityId).HasMaxLength(50).IsRequired();
            builder.Property(e => e.ProvinceId).HasMaxLength(50).IsRequired();
            builder.Property(e => e.CountryId).HasMaxLength(50).IsRequired();
            builder.Property(e => e.ZipCode).HasMaxLength(10);
            builder.Property(e => e.OwnershipCode).HasMaxLength(50).IsRequired();

            // Alamat Tinggal Sekarang
            builder.Property(e => e.CurrAddress).HasMaxLength(500).IsRequired();
            builder.Property(e => e.CurrRT).HasMaxLength(10);
            builder.Property(e => e.CurrRW).HasMaxLength(10);
            builder.Property(e => e.CurrSubDistrict).HasMaxLength(100);
            builder.Property(e => e.CurrDistrict).HasMaxLength(100);
            builder.Property(e => e.CurrCityId).HasMaxLength(50).IsRequired();
            builder.Property(e => e.CurrProvinceId).HasMaxLength(50).IsRequired();
            builder.Property(e => e.CurrCountryId).HasMaxLength(50).IsRequired();
            builder.Property(e => e.CurrZipCode).HasMaxLength(10);
            builder.Property(e => e.CurrOwnershipCode).HasMaxLength(50).IsRequired();

            // Audit Fields
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);

        }
    }
}

