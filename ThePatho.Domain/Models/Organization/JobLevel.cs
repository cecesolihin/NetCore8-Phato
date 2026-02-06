
namespace ThePatho.Domain.Models.Organization
{
    public class JobLevel
    {
        public string JobLevelCode { get; set; } = null!;
        public string JobLevelName { get; set; } = null!;
        public byte? SortOrder { get; set; }
        public string? Remarks { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
    }

}
