using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Recruitment;

namespace ThePatho.Infrastructure.Persistance.Configuration.Recruitment
{
    public class MPPConfiguration : IEntityTypeConfiguration<MPP>
    {
        public void Configure(EntityTypeBuilder<MPP> builder)
        {
            builder.ToTable(TableName.MPP);
            builder.HasKey(r => r.MppNo);
            builder.Property(r => r.MppNo).HasColumnName("mpp_no").HasMaxLength(128).IsRequired();
            builder.Property(r => r.MppYear).HasColumnName("mpp_year").HasMaxLength(255).IsRequired(false);
            builder.Property(r => r.PeriodCode).HasColumnName("period_code").HasMaxLength(128).IsRequired();
            builder.Property(r => r.Remarks).HasColumnName("remarks").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(r => r.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255).IsRequired(false);
            builder.Property(r => r.InsertedDate).HasColumnName("inserted_date").IsRequired(false);
            builder.Property(r => r.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255).IsRequired(false);
            builder.Property(r => r.ModifiedDate).HasColumnName("modified_date").IsRequired(false);

        }
    }

}
