
namespace ThePatho.Features.Organization.OrgStructure.DTO
{
    public class OrgStructureDto
    {
        public int OrgStructureId { get; set; }
        public string OrgStructureCode { get; set; }
        public string OrgStructureName { get; set; }
        public int? ParentOrgId { get; set; }
        public string OrgLevelCode { get; set; }
        public char Status { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class OrgStructureItemDto
    {
        public int DataOfRecords { get; set; }
        public List<OrgStructureDto> OrgStructureList { get; set; } = new();
    }
}
