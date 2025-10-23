namespace ThePatho.Features.Global.InventoryType.DTO
{
    public class InventoryTypeDto
    {
        public string InventoryTypeCode { get; set; } = null!;
        public string InventoryName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class InventoryTypeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<InventoryTypeDto> InventoryTypeList { get; set; } = new();
    }
}
