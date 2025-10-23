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
        }
    }
}

