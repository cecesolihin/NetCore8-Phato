using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class FamilyRelationsConfiguration : IEntityTypeConfiguration<FamilyRelation>
    {
        public void Configure(EntityTypeBuilder<FamilyRelation> builder)
        {
            builder.ToTable(TablePersonalInformation.FamilyRelation);
            builder.HasKey(x => x.RelationCode);

            builder.Property(x => x.RelationCode)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(x => x.RelationName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder.Property(x => x.InsertedBy)
                .HasMaxLength(255);

            builder.Property(x => x.InsertedDate)
                .HasColumnType("datetime");

            builder.Property(x => x.ModifiedBy)
                .HasMaxLength(255);

            builder.Property(x => x.ModifiedDate)
                .HasColumnType("datetime");

            builder.Property(x => x.RelationGender)
                .HasColumnType("nvarchar(max)");
        }
    }
}

