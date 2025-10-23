namespace ThePatho.Features.Global.Announcement.DTO
{
    public class AnnouncementDto
    {
        public int AnnouncementId { get; set; }
        public string AnnounceSubject { get; set; } = null!;
        public string? AnnounceImage { get; set; }
        public string? Attachment { get; set; }
        public string? AnnounceContent { get; set; }
        public int? Status { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public int? ActiveStatus { get; set; }
    }

    public class AnnouncementItemDto
    {
        public int DataOfRecords { get; set; }
        public List<AnnouncementDto> AnnouncementList { get; set; } = new();
    }
}
