namespace ThePatho.Features.Global.InventoryGroupDetail.DTO
{
    public class InventoryGroupDetailDto
    {
        public int InventoryGroupDetailId { get; set; }
        public string InventoryGroupCode { get; set; } = null!;
        public string InventoryTypeCode { get; set; } = null!;
        public string InsertedBy { get; set; } = null!;
        public string? InsertedDate { get; set; }
        public string ModifiedBy { get; set; } = null!;
        public string? ModifiedDate { get; set; }
    }

    public class InventoryGroupDetailItemDto
    {
        public int DataOfRecords { get; set; }
        public List<InventoryGroupDetailDto> InventoryGroupDetailList { get; set; } = new();
    }
}

