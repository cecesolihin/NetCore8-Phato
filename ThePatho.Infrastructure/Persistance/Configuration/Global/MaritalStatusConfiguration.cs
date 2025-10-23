using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class MaritalStatusConfiguration : IEntityTypeConfiguration<MaritalStatus>
    {
        public void Configure(EntityTypeBuilder<MaritalStatus> builder)
        {
            builder.ToTable(TableGlobal.MaritalStatus);

            builder.HasKey(e => e.MaritalStatusCode);
            builder.Property(e => e.MaritalStatusCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.MaritalStatusName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
