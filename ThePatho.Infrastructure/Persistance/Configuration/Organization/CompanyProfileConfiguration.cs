using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Organization;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class CompanyProfileConfiguration : IEntityTypeConfiguration<CompanyProfile>
    {
        public void Configure(EntityTypeBuilder<CompanyProfile> builder)
        {
            builder.ToTable(TableOrganization.CompanyProfile);

            builder.HasKey(e => e.CompanyCode);
            builder.Property(e => e.CompanyCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.CompanyName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Phone).HasMaxLength(15);
            builder.Property(e => e.Fax).HasMaxLength(15);
            builder.Property(e => e.Email);
            builder.Property(e => e.CompTaxNo).HasMaxLength(20);
            builder.Property(e => e.BpjsTKCardNo).HasMaxLength(255);
            builder.Property(e => e.BpjsTKRegNo).HasMaxLength(100);
            builder.Property(e => e.BpjsKSCardNo).HasMaxLength(255);
            builder.Property(e => e.BpjsKSRegNo).HasMaxLength(100);
            builder.Property(e => e.Abbreviation).HasMaxLength(10).IsRequired();
            builder.Property(e => e.MainBusiness).HasMaxLength(255);
            builder.Property(e => e.Address).HasMaxLength(200);
            builder.Property(e => e.ZipCode).HasMaxLength(10);
            builder.Property(e => e.Logo);
            builder.Property(e => e.City).HasMaxLength(30);
            builder.Property(e => e.CountryCode);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.TaxPenaltyByEmp);
            builder.Property(e => e.TaxPenaltyByComp);
            builder.Property(e => e.TaxLocationID);
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
            builder.Property(e => e.GeneralSettings_ConfigGuid).HasMaxLength(128);
            builder.Property(e => e.BPJSTKLocation).HasMaxLength(50);
            builder.Property(e => e.BPJSKesLocation).HasMaxLength(50);
            builder.Property(e => e.Phone_UPIN).HasMaxLength(15);
            builder.Property(e => e.Fax_UPIN).HasMaxLength(15);
            builder.Property(e => e.Email_UPIN);
            builder.Property(e => e.Abbreviation_UPIN).HasMaxLength(10).IsRequired();
            builder.Property(e => e.MainBusiness_UPIN).HasMaxLength(255);
            builder.Property(e => e.Address_UPIN).HasMaxLength(200);
            builder.Property(e => e.ZipCode_UPIN).HasMaxLength(10);
            builder.Property(e => e.City_UPIN).HasMaxLength(30);
            builder.Property(e => e.CountryCode_UPIN);
            builder.Property(e => e.CheckedById);
            builder.Property(e => e.Approved1Id);
            builder.Property(e => e.Approved2Id);
            builder.Property(e => e.PreparedId);
        }
    }
}
