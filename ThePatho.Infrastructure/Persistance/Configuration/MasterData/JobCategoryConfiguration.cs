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
    public class JobCategoryConfiguration : IEntityTypeConfiguration<JobCategory>
    {
        public void Configure(EntityTypeBuilder<JobCategory> builder)
        {
            builder.ToTable(TableName.JobCategory);

            builder.HasKey(e => new { e.JobCategoryId, e.JobCategoryCode });

            builder.Property(e => e.JobCategoryId).HasColumnName("job_category_id").ValueGeneratedOnAdd();
            builder.Property(e => e.JobCategoryCode).HasColumnName("job_category_code").HasMaxLength(128).IsRequired();
            builder.Property(e => e.JobCategoryName).HasColumnName("job_category_name");
            builder.Property(e => e.IsCategory).HasColumnName("is_category").IsRequired();
            builder.Property(e => e.ParentCategory).HasColumnName("parent_category");
            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");

        }
    }
}
