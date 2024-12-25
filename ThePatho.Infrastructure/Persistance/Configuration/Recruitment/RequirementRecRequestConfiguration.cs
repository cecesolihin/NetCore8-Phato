using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Recruitment;

namespace ThePatho.Infrastructure.Persistance.Configuration.Recruitment
{
    public class RequirementRecRequestConfiguration : IEntityTypeConfiguration<RequirementRecRequest>
    {
        public void Configure(EntityTypeBuilder<RequirementRecRequest> builder)
        {
            builder.ToTable(TableName.RequirementRecRequest);
            builder.HasKey(r => new { r.RequestNo, r.QuestionCode }); 
            builder.Property(r => r.RequestNo).HasColumnName("request_no").HasMaxLength(128).IsRequired();
            builder.Property(r => r.QuestionCode).HasColumnName("question_code").HasMaxLength(128).IsRequired();
            builder.Property(r => r.Answer).HasColumnName("answer").HasMaxLength(128).IsRequired();
            builder.Property(r => r.InsertedBy).HasColumnName("inserted_by").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(r => r.InsertedDate).HasColumnName("inserted_date").IsRequired(false);
            builder.Property(r => r.ModifiedBy).HasColumnName("modified_by").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(r => r.ModifiedDate).HasColumnName("modified_date").IsRequired(false);

        }
    }

}
