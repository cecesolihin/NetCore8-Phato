
namespace ThePatho.Features.Organization.Position.DTO
{
    public class PositionDto
    {
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public string JobLevelCode { get; set; }
        public int OrgStructureId { get; set; }
        public bool ActAsHead { get; set; }
        public string? Objective { get; set; }
        public string? JobDescription { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class PositionItemDto
    {
        public int DataOfRecords { get; set; }
        public List<PositionDto> PositionList { get; set; } = new();
    }
}
