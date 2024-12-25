
namespace ThePatho.Features.MasterData.JobCategory.DTO
{
    public class JobCategoryItemDto
    {
        public int DataOfRecords { get; set; }
        public List<JobCategoryDto> JobCategoryList { get; set; } = new();
    }
    public class JobCategoryDto
    {
        public int JobCategoryId { get; set; }
        public string JobCategoryCode { get; set; } = null!;
        public string? JobCategoryName { get; set; }
        public bool IsCategory { get; set; }
        public int? ParentCategory { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
