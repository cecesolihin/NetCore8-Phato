using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Domain.Models.Applicant;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Applicant
{
    public class ApplicantPersonalDataConfiguration : IEntityTypeConfiguration<ApplicantPersonalData>
    {
        public void Configure(EntityTypeBuilder<ApplicantPersonalData> builder)
        {
            builder.ToTable(TableName.ApplicantPersonalData);
            // Primary Key
            builder.HasKey(a => a.ApplicantNo);

            // Properties
            builder.Property(a => a.NationalityId).HasColumnName("nationality_id").IsRequired(false);
            builder.Property(a => a.ReligionId).HasColumnName("religion_id").IsRequired(false);
            builder.Property(a => a.MaritalStatus).HasColumnName("marital_status").HasMaxLength(50);
            builder.Property(a => a.MarriedDate).HasColumnName("married_date").HasColumnType("datetime");
            builder.Property(a => a.NickName).HasColumnName("nick_name").HasMaxLength(100);
            builder.Property(a => a.Phone).HasColumnName("phone").HasMaxLength(20);
            builder.Property(a => a.MobilePhone).HasColumnName("mobile_phone").HasMaxLength(20);
            builder.Property(a => a.Email).HasColumnName("email").HasMaxLength(100);
            builder.Property(a => a.BloodType).HasColumnName("blood_type").HasMaxLength(10);
            builder.Property(a => a.Height).HasColumnName("height").IsRequired(false);
            builder.Property(a => a.Weight).HasColumnName("weight").IsRequired(false);
            builder.Property(a => a.Photo).HasColumnName("photo").HasColumnType("varbinary(max)");
            builder.Property(a => a.Reference).HasColumnName("reference").HasMaxLength(500);
            builder.Property(a => a.EmergencyContactName).HasColumnName("emergency_contact_name").HasMaxLength(100);
            builder.Property(a => a.EmergencyContact).HasColumnName("emergency_contact").HasMaxLength(20);
            builder.Property(a => a.InsertedBy).HasColumnName("inserted_by").HasMaxLength(50);
            builder.Property(a => a.ModifiedBy).HasColumnName("modified_by").HasMaxLength(50);


        }
    }

}
