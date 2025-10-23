using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Organization;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class CompanyBankConfiguration : IEntityTypeConfiguration<CompanyBank>
    {
        public void Configure(EntityTypeBuilder<CompanyBank> builder)
        {
            builder.ToTable(TableOrganization.CompanyBank);

            builder.HasKey(e => e.CompanyBankId);
            builder.Property(e => e.CompanyBankId).ValueGeneratedOnAdd();
            builder.Property(e => e.CompanyCode).HasMaxLength(128);
            builder.Property(e => e.BankCode).HasMaxLength(128);
            builder.Property(e => e.Branch).HasMaxLength(255).IsRequired();
            builder.Property(e => e.AccountNo).HasMaxLength(20);
            builder.Property(e => e.AccountName).HasMaxLength(255);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.IsDefault);
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
