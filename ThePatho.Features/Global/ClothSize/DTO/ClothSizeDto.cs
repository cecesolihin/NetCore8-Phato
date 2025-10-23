namespace ThePatho.Features.Global.ClothSize.DTO
{
    public class ClothSizeDto
    {
        public string ClothSizeCode { get; set; } = null!;
        public string ClothSizeName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class ClothSizeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<ClothSizeDto> ClothSizeList { get; set; } = new();
    }
}
