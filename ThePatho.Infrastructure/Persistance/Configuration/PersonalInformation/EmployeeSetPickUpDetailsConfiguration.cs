using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeeSetPickUpDetailsConfiguration : IEntityTypeConfiguration<EmployeeSetPickUpDetail>
    {
        public void Configure(EntityTypeBuilder<EmployeeSetPickUpDetail> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeeSetPickUpDetail);
        }
    }
}

