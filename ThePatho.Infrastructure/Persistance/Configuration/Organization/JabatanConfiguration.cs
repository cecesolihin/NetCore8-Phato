using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Organization;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class JabatanConfiguration : IEntityTypeConfiguration<Jabatan>
    {
        public void Configure(EntityTypeBuilder<Jabatan> builder)
        {
            builder.ToTable(TableOrganization.Jabatan);

            builder.HasKey(e => e.JabatanId);
            builder.Property(e => e.JabatanId).ValueGeneratedOnAdd();
            builder.Property(e => e.JabatanCode).HasMaxLength(50).IsRequired();
            builder.Property(e => e.JabatanName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.JabatanDescription).HasMaxLength(500);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
