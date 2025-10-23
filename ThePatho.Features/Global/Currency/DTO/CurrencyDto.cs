namespace ThePatho.Features.Global.Currency.DTO
{
    public class CurrencyDto
    {
        public string CurrencyCode { get; set; } = null!;
        public string CurrencyName { get; set; } = null!;
        public string Symbol { get; set; } = null!;
        public int DecimalDigit { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class CurrencyItemDto
    {
        public int DataOfRecords { get; set; }
        public List<CurrencyDto> CurrencyList { get; set; } = new();
    }
}
