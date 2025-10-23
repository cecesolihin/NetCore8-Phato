using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeeCustomFieldConfiguration : IEntityTypeConfiguration<EmployeeCustomField>
    {
        public void Configure(EntityTypeBuilder<EmployeeCustomField> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeeCustomField);

            builder.HasKey(e => e.EmpCustomFieldID);
            builder.Property(e => e.EmpCustomFieldID).ValueGeneratedOnAdd();
            builder.Property(e => e.EmployeeID).IsRequired();

            // Custom Fields 1-20
            builder.Property(e => e.CustomField1).HasMaxLength(255);
            builder.Property(e => e.CustomField2).HasMaxLength(255);
            builder.Property(e => e.CustomField3).HasMaxLength(255);
            builder.Property(e => e.CustomField4).HasMaxLength(255);
            builder.Property(e => e.CustomField5).HasMaxLength(255);
            builder.Property(e => e.CustomField6).HasMaxLength(255);
            builder.Property(e => e.CustomField7).HasMaxLength(255);
            builder.Property(e => e.CustomField8).HasMaxLength(255);
            builder.Property(e => e.CustomField9).HasMaxLength(255);
            builder.Property(e => e.CustomField10).HasMaxLength(255);
            builder.Property(e => e.CustomField11).HasMaxLength(255);
            builder.Property(e => e.CustomField12).HasMaxLength(255);
            builder.Property(e => e.CustomField13).HasMaxLength(255);
            builder.Property(e => e.CustomField14).HasMaxLength(255);
            builder.Property(e => e.CustomField15).HasMaxLength(255);
            builder.Property(e => e.CustomField16).HasMaxLength(255);
            builder.Property(e => e.CustomField17).HasMaxLength(255);
            builder.Property(e => e.CustomField18).HasMaxLength(255);
            builder.Property(e => e.CustomField19).HasMaxLength(255);
            builder.Property(e => e.CustomField20).HasMaxLength(255);

            // Audit Fields
            builder.Property(e => e.InsertedBy);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

