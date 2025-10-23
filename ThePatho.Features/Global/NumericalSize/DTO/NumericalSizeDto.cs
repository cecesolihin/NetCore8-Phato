namespace ThePatho.Features.Global.NumericalSize.DTO
{
    public class NumericalSizeDto
    {
        public int NumericalSizeId { get; set; }
        public string NumericalSizeName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class NumericalSizeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<NumericalSizeDto> NumericalSizeList { get; set; } = new();
    }
}
