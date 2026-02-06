namespace ThePatho.Features.Organization.Grade.DTO
{
    public class GradeDto
    {
        public string GradeCode { get; set; } = null!;
        public string GradeName { get; set; } = null!;
        public string? Status { get; set; }
        public byte SortOrder { get; set; }
        public string? Remarks { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class GradeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<GradeDto> GradeList { get; set; } = new();
    }
}
