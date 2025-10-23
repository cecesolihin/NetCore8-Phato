namespace ThePatho.Features.Global.ShoeSize.DTO
{
    public class ShoeSizeDto
    {
        public string ShoeSizeCode { get; set; } = null!;
        public string ShoeSizeName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class ShoeSizeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<ShoeSizeDto> ShoeSizeList { get; set; } = new();
    }
}
