using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;
namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class MedicalGroupConfiguration : IEntityTypeConfiguration<MedicalGroup>
    {
        public void Configure(EntityTypeBuilder<MedicalGroup> builder)
        {
            builder.ToTable(TableGlobal.MedicalGroup);

            builder.HasKey(e => e.MedicalGroupCode);
            builder.Property(e => e.MedicalGroupCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.MedicalGroupName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
