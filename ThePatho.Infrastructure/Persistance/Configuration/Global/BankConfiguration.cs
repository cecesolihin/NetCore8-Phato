using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.ToTable(TableGlobal.Bank);

            builder.HasKey(e => e.BankCode);

            builder.Property(e => e.BankCode)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.CurrencyCode)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(e => e.TransferCode)
                .HasMaxLength(50);

            builder.Property(e => e.TransdferFee)
                .HasColumnType("decimal(17,2)");

            builder.Property(e => e.IsDeleted)
                .IsRequired();

            builder.Property(e => e.InsertedBy)
                .HasMaxLength(255);

            builder.Property(e => e.InsertedDate);

            builder.Property(e => e.ModifiedBy)
                .HasMaxLength(255);

            builder.Property(e => e.ModifiedDate);

            builder.Property(e => e.BranchName)
                .HasMaxLength(500);

            builder.Property(e => e.SwiftCode)
                .HasMaxLength(100);
        }
    }
}
