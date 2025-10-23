namespace ThePatho.Features.Global.InventoryGroupOrg.DTO
{
    public class InventoryGroupOrgDto
    {
        public int InventoryGroupOrgId { get; set; }
        public string InventoryGroupCode { get; set; } = null!;
        public string OrganizationCode { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class InventoryGroupOrgItemDto
    {
        public int DataOfRecords { get; set; }
        public List<InventoryGroupOrgDto> InventoryGroupOrgList { get; set; } = new();
    }
}

