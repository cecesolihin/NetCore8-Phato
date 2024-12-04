using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models;

namespace ThePatho.Infrastructure.Persistance.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(TableName.Category);

            builder.HasKey(e => e.TrainingCategoryCode).HasName("PK_TTRMCategory");

            builder.Property(e => e.TrainingCategoryCode)
                .HasColumnName("training_category_code")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(e => e.TrainingCategoryName)
                .HasColumnName("training_category_name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.InsertedBy)
                .HasColumnName("inserted_by")
                .HasMaxLength(255);

            builder.Property(e => e.InsertedDate)
                .HasColumnName("inserted_date");

            builder.Property(e => e.ModifiedBy)
                .HasColumnName("modified_by")
                .HasMaxLength(255);

            builder.Property(e => e.ModifiedDate)
                .HasColumnName("modified_date");
        }
    }
}
