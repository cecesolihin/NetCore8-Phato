using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Global;

namespace ThePatho.Infrastructure.Persistance.Configuration.Global
{
    public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.ToTable(TableGlobal.Announcement);

            builder.HasKey(e => e.AnnouncementID);
            builder.Property(e => e.AnnouncementID).ValueGeneratedOnAdd();
            builder.Property(e => e.AnnounceSubject).HasMaxLength(50).IsRequired();
            builder.Property(e => e.AnnounceImage);
            builder.Property(e => e.Attachment);
            builder.Property(e => e.AnnounceContent);
            builder.Property(e => e.Status);
            builder.Property(e => e.InsertedBy).HasMaxLength(255);
            builder.Property(e => e.InsertedDate);
            builder.Property(e => e.ModifiedBy).HasMaxLength(255);
            builder.Property(e => e.ModifiedDate);
            builder.Property(e => e.ActiveStatus);
        }
    }
}
