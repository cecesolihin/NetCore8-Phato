using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Domain.Models.MasterData;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.MasterData
{
    public class AdsCategoryConfiguration : IEntityTypeConfiguration<AdsCategory>
    {
        public void Configure(EntityTypeBuilder<AdsCategory> builder)
        {
            builder.ToTable(TableName.AdsCategory);
            builder.ToTable("TMAdsCategory");

            builder.HasKey(e => e.AdsCategoryCode);

            builder.Property(e => e.AdsCategoryCode).HasColumnName("ads_category_code").HasMaxLength(128).IsRequired();
            builder.Property(e => e.AdsCategoryName).HasColumnName("ads_category_name");
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");

        }
    }
}
