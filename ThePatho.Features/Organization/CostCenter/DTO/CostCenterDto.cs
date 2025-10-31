namespace ThePatho.Features.Organization.CostCenter.DTO
{
    public class CostCenterDto
    {
        public string CostCenterCode { get; set; } = null!;
        public string CostCenterName { get; set; } = null!;
        public byte Sort { get; set; }
        public bool IsDeleted { get; set; }
        public string? CostCenterType { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class CostCenterItemDto
    {
        public int DataOfRecords { get; set; }
        public List<CostCenterDto> CostCenterList { get; set; } = new();
    }
}
