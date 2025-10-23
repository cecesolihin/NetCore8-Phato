using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeePickUpConfiguration : IEntityTypeConfiguration<EmployeePickUp>
    {
        public void Configure(EntityTypeBuilder<EmployeePickUp> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeePickUp);
        }
    }
}

