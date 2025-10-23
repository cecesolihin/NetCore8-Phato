namespace ThePatho.Features.Global.InventoryCondition.DTO
{
    public class InventoryConditionDto
    {
        public string InventoryConditionCode { get; set; } = null!;
        public string InventoryConditionName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class InventoryConditionItemDto
    {
        public int DataOfRecords { get; set; }
        public List<InventoryConditionDto> InventoryConditionList { get; set; } = new();
    }
}
