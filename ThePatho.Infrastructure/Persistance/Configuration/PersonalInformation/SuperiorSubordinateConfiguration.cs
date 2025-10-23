using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class SuperiorSubordinateConfiguration : IEntityTypeConfiguration<SuperiorSubordinate>
    {
        public void Configure(EntityTypeBuilder<SuperiorSubordinate> builder)
        {
            builder.ToTable(TablePersonalInformation.SuperiorSubordinate);
            builder.HasKey(e => e.EmployeeSuperiorID);

            builder.Property(e => e.EmployeeSuperiorID)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.EmployeeID)
                .IsRequired();

            builder.Property(e => e.EffectiveDate)
                .IsRequired()
                .HasColumnType("datetime2(7)");

            builder.Property(e => e.EndDate)
                .HasColumnType("datetime");

            builder.Property(e => e.Remarks)
                .HasColumnType("nvarchar(max)");

            // Generate mapping for 30 SuperiorID columns
            for (int i = 1; i <= 30; i++)
            {
                builder.Property<int?>($"Superior{i}ID")
                    .HasColumnName($"Superior{i}ID")
                    .IsRequired(false);
            }

            builder.Property(e => e.InsertedBy)
                .HasMaxLength(255);

            builder.Property(e => e.InsertedDate)
                .HasColumnType("datetime");

            builder.Property(e => e.ModifiedBy)
                .HasMaxLength(255);

            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime");
        }
    }
}
