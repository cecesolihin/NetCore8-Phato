using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Global
{
    public class Announcement
    {
        public int AnnouncementID { get; set; }
        public string AnnounceSubject { get; set; } = null!;
        public string? AnnounceImage { get; set; }
        public string? Attachment { get; set; }
        public string? AnnounceContent { get; set; }
        public int? Status { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ActiveStatus { get; set; }
    }
}
