using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;
namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class ResignReasonConfiguration : IEntityTypeConfiguration<ResignReason>
    {
        public void Configure(EntityTypeBuilder<ResignReason> builder)
        {
            builder.ToTable(TableGlobal.ResignReason);

            builder.HasKey(e => e.ResignReasonCode);
            builder.Property(e => e.ResignReasonCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.ResignReasonName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
