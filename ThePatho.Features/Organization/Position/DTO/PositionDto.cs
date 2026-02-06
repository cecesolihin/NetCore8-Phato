
namespace ThePatho.Features.Organization.Position.DTO
{
    public class PositionDto
    {
        public string PositionCode { get; set; } = null!;
        public string PositionName { get; set; } = null!;
        public string JobLevelCode { get; set; } = null!;
        public int OrgStructureID { get; set; }
        public bool ActAsHead { get; set; }
        public string? Objective { get; set; }
        public string? JobDescription { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? DocumentNo { get; set; }
        public bool IsActive { get; set; }
        public string? ParentPositionCode { get; set; }
        public string? PositionPath { get; set; }
    }
    public class PositionItemDto
    {
        public int DataOfRecords { get; set; }
        public List<PositionDto> PositionList { get; set; } = new();
    }
}
