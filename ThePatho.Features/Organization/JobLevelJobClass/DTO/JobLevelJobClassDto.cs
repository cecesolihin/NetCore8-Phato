namespace ThePatho.Features.Organization.JobLevelJobClass.DTO
{
    public class JobLevelJobClassDto
    {
        public string JobLevelCode { get; set; } = null!;
        public string JobClassCode { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class JobLevelJobClassItemDto
    {
        public int DataOfRecords { get; set; }
        public List<JobLevelJobClassDto> JobLevelJobClassList { get; set; } = new();
    }
}
