namespace ThePatho.Features.Global.Country.DTO
{
    public class CountryDto
    {
        public int CountryId { get; set; }
        public int? Sort { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; } = null!;
        public int NumericIsoCode { get; set; }
        public string? ThreeLetterIsoCode { get; set; }
        public string? TwoLetterIsoCode { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class CountryItemDto
    {
        public int DataOfRecords { get; set; }
        public List<CountryDto> CountryList { get; set; } = new();
    }
}
