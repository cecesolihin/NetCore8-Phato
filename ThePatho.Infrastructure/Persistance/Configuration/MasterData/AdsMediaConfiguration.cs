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
    public class AdsMediaConfiguration : IEntityTypeConfiguration<AdsMedia>
    {
        public void Configure(EntityTypeBuilder<AdsMedia> builder)
        {
            builder.ToTable(TableName.AdsMedia);

            builder.HasKey(e => e.AdsCode);

            builder.Property(e => e.AdsCode).HasColumnName("ads_code").HasMaxLength(128).IsRequired();
            builder.Property(e => e.AdsName).HasColumnName("ads_name");
            builder.Property(e => e.AdsCategoryCode).HasColumnName("ads_category_code").HasMaxLength(128).IsRequired();
            builder.Property(e => e.Phone).HasColumnName("phone");
            builder.Property(e => e.ContactPerson).HasColumnName("contact_person");
            builder.Property(e => e.Remarks).HasColumnName("remarks");
            builder.Property(e => e.UseRecruitmentFee).HasColumnName("use_recruitment_fee").IsRequired();
            builder.Property(e => e.RecruitmentFee).HasColumnName("recruitment_fee");
            builder.Property(e => e.RecruitmentFee2).HasColumnName("recruitment_fee_2");
            builder.Property(e => e.RecruitmentFee3).HasColumnName("recruitment_fee_3");
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");

        }
    }
}
