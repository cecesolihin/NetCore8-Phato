namespace ThePatho.Features.Organization.JobClass.DTO
{
    public class JobClassDto
    {
        public string JobClassCode { get; set; } = null!;
        public string JobClassName { get; set; } = null!;
        public string GradeCode { get; set; } = null!;
        public string RankCode { get; set; } = null!;
        public string? Remarks { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
    }

    public class JobClassItemDto
    {
        public int DataOfRecords { get; set; }
        public List<JobClassDto> JobClassList { get; set; } = new();
    }
}
