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
    public class EmployeeMedicalConfiguration : IEntityTypeConfiguration<EmployeeMedical>
    {
        public void Configure(EntityTypeBuilder<EmployeeMedical> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeeMedical);

            // Composite Primary Key
            builder.HasKey(e => new { e.EmployeeID, e.DiseaseCategoryCode, e.DiseaseName, e.StartDate });

            builder.Property(e => e.EmployeeID).IsRequired();
            builder.Property(e => e.DiseaseCategoryCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.DiseaseName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e => e.EndDate).IsRequired();
            builder.Property(e => e.Therapy).HasMaxLength(100);
            builder.Property(e => e.Hospital).HasMaxLength(100);
            builder.Property(e => e.CountryId).HasMaxLength(100);
            builder.Property(e => e.ProvinceId).HasMaxLength(100);
            builder.Property(e => e.CityCode).HasMaxLength(100);
            builder.Property(e => e.Doctor).HasMaxLength(100);
            builder.Property(e => e.Phone).HasMaxLength(100);
            builder.Property(e => e.Remarks);
            builder.Property(e => e.TimeIn);
            builder.Property(e => e.TimeOut);
            builder.Property(e => e.Obat);
            builder.Property(e => e.TindakanPertama);
            builder.Property(e => e.TindakanKedua);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

