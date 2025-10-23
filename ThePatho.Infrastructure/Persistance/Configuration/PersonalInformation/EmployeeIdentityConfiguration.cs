using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Domain.Models.PersonalInformation;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeeIdentityConfiguration : IEntityTypeConfiguration<EmployeeIdentity>
    {
        public void Configure(EntityTypeBuilder<EmployeeIdentity> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeeIdentity);

            // Composite Primary Key
            builder.HasKey(e => new { e.EmployeeID, e.IdentityCode });

            builder.Property(e => e.EmployeeID).IsRequired();
            builder.Property(e => e.IdentityCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.CompanyCode);
            builder.Property(e => e.IdentityNo).IsRequired();
            builder.Property(e => e.IssuedDate);
            builder.Property(e => e.ExpiredDate);
            builder.Property(e => e.FileUpload);
            builder.Property(e => e.Remarks);
            builder.Property(e => e.FileFullPath);
            builder.Property(e => e.FileName);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

