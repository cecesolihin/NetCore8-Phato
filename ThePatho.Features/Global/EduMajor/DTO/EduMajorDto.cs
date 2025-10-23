namespace ThePatho.Features.Global.EduMajor.DTO
{
    public class EduMajorDto
    {
        public string MajorCode { get; set; } = null!;
        public string MajorName { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class EduMajorItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EduMajorDto> EduMajorList { get; set; } = new();
    }
}

