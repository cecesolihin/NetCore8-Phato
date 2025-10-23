namespace ThePatho.Features.Global.Province.DTO
{
    public class ProvinceDto
    {
        public int ProvinceId { get; set; }
        public string? Abbreviation { get; set; }
        public int CountryId { get; set; }
        public int? Sort { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class ProvinceItemDto
    {
        public int DataOfRecords { get; set; }
        public List<ProvinceDto> ProvinceList { get; set; } = new();
    }
}
