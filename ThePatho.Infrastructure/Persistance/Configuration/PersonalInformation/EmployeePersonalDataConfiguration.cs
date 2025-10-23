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
    public class EmployeePersonalDataConfiguration : IEntityTypeConfiguration<EmployeePersonalData>
    {
        public void Configure(EntityTypeBuilder<EmployeePersonalData> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeePersonalData);

            // Composite Primary Key
            builder.HasKey(e => new { e.EmployeeID, e.CompanyCode });

            builder.Property(e => e.EmployeeID).IsRequired();
            builder.Property(e => e.CompanyCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.NationalityID);
            builder.Property(e => e.ReligionID);
            builder.Property(e => e.MaritalStatus).HasMaxLength(10).IsRequired();
            builder.Property(e => e.MarriedDate);
            builder.Property(e => e.BPJSTK).HasMaxLength(50);
            builder.Property(e => e.BPJSKES).HasMaxLength(50);
            builder.Property(e => e.NickName).HasMaxLength(50);
            builder.Property(e => e.Phone).HasMaxLength(50);
            builder.Property(e => e.MobilePhone).HasMaxLength(50);
            builder.Property(e => e.Email).HasMaxLength(255);
            builder.Property(e => e.BloodType).HasMaxLength(5);
            builder.Property(e => e.Height);
            builder.Property(e => e.Weight);
            builder.Property(e => e.OfficePhone).HasMaxLength(50);
            builder.Property(e => e.OfficeEmail).HasMaxLength(255);
            builder.Property(e => e.BuildingCode).HasMaxLength(50);
            builder.Property(e => e.RoomCode).HasMaxLength(50);
            builder.Property(e => e.ComputerName).HasMaxLength(255);
            builder.Property(e => e.StaticIPAddress).HasMaxLength(50);
            builder.Property(e => e.Glasses);
            builder.Property(e => e.LeftEye).HasMaxLength(50);
            builder.Property(e => e.RightEye).HasMaxLength(50);
            builder.Property(e => e.Hat).HasMaxLength(10);
            builder.Property(e => e.Helmet).HasMaxLength(10);
            builder.Property(e => e.Clothes).HasMaxLength(10);
            builder.Property(e => e.Jacket).HasMaxLength(10);
            builder.Property(e => e.Pants).HasMaxLength(10);
            builder.Property(e => e.Shoes).HasMaxLength(10);
            builder.Property(e => e.Boots).HasMaxLength(10);
            builder.Property(e => e.Photo);
            builder.Property(e => e.RFID);
            builder.Property(e => e.Recruiter);
            builder.Property(e => e.HireOrigin);
            builder.Property(e => e.PayGroup);
            builder.Property(e => e.PhotoPath);

            // Boolean flags
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.SeverancePaid).IsRequired();
            builder.Property(e => e.StatusIDCard).IsRequired();
            builder.Property(e => e.IsDonate).IsRequired();

            builder.Property(e => e.SeverancePaidDate);
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

