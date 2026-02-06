namespace ThePatho.Features.Organization.HistOrgStructure.DTO
{
    public class HistOrgStructureDto
    {
        public int HistOrgStructureId { get; set; }
        public int OrgStructureId { get; set; }
        public string OrgStructureCode { get; set; } = null!;
        public string OrgStructureName { get; set; } = null!;
        public int? ParentOrgStructureId { get; set; }
        public string OrgLevelCode { get; set; } = null!;
        public bool IsActive { get; set; }
        public string? CostCenterCode { get; set; }
        public string? Location { get; set; }
        public string? Phone { get; set; }
        public string? PhoneExt { get; set; }
        public byte SortOrder { get; set; }
        public string CompanyCode { get; set; } = null!;
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public bool IsDeleted { get; set; }
        public string? Path { get; set; }
        public string? Function { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class HistOrgStructureItemDto
    {
        public int DataOfRecords { get; set; }
        public List<HistOrgStructureDto> HistOrgStructureList { get; set; } = new();
    }
}
