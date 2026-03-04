using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.PersonalInformation;

namespace ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation
{
    public class EmployeeInventoryConfiguration : IEntityTypeConfiguration<EmployeeInventory>
    {
        public void Configure(EntityTypeBuilder<EmployeeInventory> builder)
        {
            builder.ToTable(TablePersonalInformation.EmployeeInventory);

            // Composite Primary Key
            builder.HasKey(e => new { e.EmployeeID, e.InventoryNo });

            builder.Property(e => e.EmployeeID).IsRequired();
            builder.Property(e => e.InventoryNo).HasMaxLength(128).IsRequired();
            builder.Property(e => e.InventoryTpyeCode).HasMaxLength(128).IsRequired();
            builder.Property(e => e.InventoryName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.ReceivedDate);
            builder.Property(e => e.ReturnPlanDate);
            builder.Property(e => e.ReceivedQty).IsRequired();
            builder.Property(e => e.Size).HasMaxLength(50).IsRequired();
            builder.Property(e => e.ReceivedCondition);
            builder.Property(e => e.ReceivedRemark).HasMaxLength(500);
            builder.Property(e => e.ReturnDate);
            builder.Property(e => e.ReturnCondition).HasMaxLength(128);
            builder.Property(e => e.ReturnRemark).HasMaxLength(500);
            builder.Property(e => e.InsertedBy);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy);
            builder.Property(e => e.ModifiedDate);
        }
    }
}

