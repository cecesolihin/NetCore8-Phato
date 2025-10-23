using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class BranchBankConfiguration : IEntityTypeConfiguration<BranchBank>
    {
        public void Configure(EntityTypeBuilder<BranchBank> builder)
        {
            builder.ToTable(TableGlobal.BranchBank);

            builder.HasKey(e => e.BranchBankCode);
            builder.Property(e => e.BranchBankCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.BranchBankName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
