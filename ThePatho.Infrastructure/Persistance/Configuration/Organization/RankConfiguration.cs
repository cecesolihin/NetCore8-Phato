using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Organization;

namespace ThePatho.Infrastructure.Persistance.Configuration.Organization
{
    public class RankConfiguration : IEntityTypeConfiguration<Rank>
    {
        public void Configure(EntityTypeBuilder<Rank> builder)
        {
            builder.ToTable(TableOrganization.Rank);

            builder.HasKey(e => e.RankCode);
            builder.Property(e => e.RankCode).HasMaxLength(50).IsRequired();
            builder.Property(e => e.RankName).HasMaxLength(255).IsRequired();
            builder.Property(e => e.SortOrder).IsRequired();
            builder.Property(e => e.Remarks).HasMaxLength(500);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
