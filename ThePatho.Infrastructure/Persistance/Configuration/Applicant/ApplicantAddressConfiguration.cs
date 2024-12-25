using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Models.Applicant;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Applicant
{
    public class ApplicantAddressConfiguration : IEntityTypeConfiguration<ApplicantAddress>
    {
        public void Configure(EntityTypeBuilder<ApplicantAddress> builder)
        {
            builder.ToTable(TableName.ApplicantAddress);
            builder.HasKey(e => e.ApplicantNo);

            builder.Property(e => e.ApplicantNo).HasColumnName("applicant_no").HasMaxLength(128);
            builder.Property(e => e.Address).HasColumnName("address").HasMaxLength(500);
            builder.Property(e => e.RT).HasColumnName("rt").HasMaxLength(3);
            builder.Property(e => e.RW).HasColumnName("rw").HasMaxLength(3);
            builder.Property(e => e.SubDistrict).HasColumnName("sub_district").HasMaxLength(100);
            builder.Property(e => e.District).HasColumnName("district").HasMaxLength(100);
            builder.Property(e => e.City).HasColumnName("city").HasMaxLength(100);
            builder.Property(e => e.Province).HasColumnName("province").HasMaxLength(100);
            builder.Property(e => e.Country).HasColumnName("country").HasMaxLength(100);
            builder.Property(e => e.ZipCode).HasColumnName("zip_code").HasMaxLength(5);
            builder.Property(e => e.Ownership).HasColumnName("ownership");
            builder.Property(e => e.CurrAddress).HasColumnName("curr_address").HasMaxLength(500);
            builder.Property(e => e.CurrRT).HasColumnName("curr_rt").HasMaxLength(3);
            builder.Property(e => e.CurrRW).HasColumnName("curr_rw").HasMaxLength(3);
            builder.Property(e => e.CurrSubDistrict).HasColumnName("curr_sub_district").HasMaxLength(100);
            builder.Property(e => e.CurrDistrict).HasColumnName("curr_district").HasMaxLength(100);
            builder.Property(e => e.CurrCity).HasColumnName("curr_city").HasMaxLength(100);
            builder.Property(e => e.CurrProvince).HasColumnName("curr_province").HasMaxLength(100);
            builder.Property(e => e.CurrCountry).HasColumnName("curr_country").HasMaxLength(100);
            builder.Property(e => e.CurrZipCode).HasColumnName("curr_zip_code").HasMaxLength(5);
            builder.Property(e => e.CurrOwnership).HasColumnName("curr_ownership");
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by");
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");
        }
    }

}
