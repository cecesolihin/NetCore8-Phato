namespace ThePatho.Features.Global.TaxStatus.DTO
{
    public class TaxStatusDto
    {
        public string TaxStatusCode { get; set; } = null!;
        public string TaxStatusName { get; set; } = null!;
        public string Married { get; set; } = null!;
        public byte TotalDependents { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class TaxStatusItemDto
    {
        public int DataOfRecords { get; set; }
        public List<TaxStatusDto> TaxStatusList { get; set; } = new();
    }
}
