using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Models.Recruitment;
using ThePatho.Domain.Constants;

namespace ThePatho.Infrastructure.Persistance.Configuration.Recruitment
{
    public class RequirementMasterConfiguration : IEntityTypeConfiguration<RequirementMaster>
    {
        public void Configure(EntityTypeBuilder<RequirementMaster> builder)
        {
            builder.ToTable(TableName.RequirementMaster);

            builder.HasKey(e => e.QuestionCode);

            builder.Property(e => e.QuestionCode).HasColumnName("question_code").HasMaxLength(128).IsRequired();
            builder.Property(e => e.QuestionName).HasColumnName("question_name").HasColumnType("nvarchar(max)");

            builder.Property(e => e.InsertedBy).HasColumnName("inserted_by").HasMaxLength(255);
            builder.Property(e => e.InsertedDate).HasColumnName("inserted_date");
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasMaxLength(255);
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");

        }
    }

}
