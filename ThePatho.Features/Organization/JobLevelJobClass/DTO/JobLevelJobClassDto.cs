namespace ThePatho.Features.Organization.JobLevelJobClass.DTO
{
    public class JobLevelJobClassDto
    {
        public string JobLevelCode { get; set; } = null!;
        public string JobClassCode { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string InsertedDate { get; set; } = null!;
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class JobLevelJobClassItemDto
    {
        public int DataOfRecords { get; set; }
        public List<JobLevelJobClassDto> JobLevelJobClassList { get; set; } = new();
    }
}
