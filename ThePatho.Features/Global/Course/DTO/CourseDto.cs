namespace ThePatho.Features.Global.Course.DTO
{
    public class CourseDto
    {
        public string CourseCode { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public string TrainingFieldCode { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class CourseItemDto
    {
        public int DataOfRecords { get; set; }
        public List<CourseDto> CourseList { get; set; } = new();
    }
}

