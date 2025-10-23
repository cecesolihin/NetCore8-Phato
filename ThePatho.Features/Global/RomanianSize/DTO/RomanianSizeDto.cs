namespace ThePatho.Features.Global.RomanianSize.DTO
{
    public class RomanianSizeDto
    {
        public int RomanianSizeId { get; set; }
        public string RomanianSizeName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class RomanianSizeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<RomanianSizeDto> RomanianSizeList { get; set; } = new();
    }
}
