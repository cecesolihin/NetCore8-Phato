namespace ThePatho.Features.Global.InventoryGroup.DTO
{
    public class InventoryGroupDto
    {
        public string InventoryGroupCode { get; set; } = null!;
        public string InventoryGroupName { get; set; } = null!;
        public string GroupBy { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class InventoryGroupItemDto
    {
        public int DataOfRecords { get; set; }
        public List<InventoryGroupDto> InventoryGroupList { get; set; } = new();
    }
}

