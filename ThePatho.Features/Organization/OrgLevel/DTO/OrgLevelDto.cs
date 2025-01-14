
namespace ThePatho.Features.Organization.OrgLevel.DTO
{
    public class OrgLevelDto
    {
        public string OrgLevelCode { get; set; }
        public string OrgLevelName { get; set; }
        public byte Sort { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class OrganizationLevelItemDto
    {
        public int DataOfRecords { get; set; }
        public List<OrgLevelDto> OrganizationLevelList { get; set; } = new();
    }
}
