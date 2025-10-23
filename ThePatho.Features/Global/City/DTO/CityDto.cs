namespace ThePatho.Features.Global.City.DTO
{
    public class CityDto
    {
        public int CityId { get; set; }
        public string CityCode { get; set; } = null!;
        public int ProvinceId { get; set; }
        public int? Sort { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class CityItemDto
    {
        public int DataOfRecords { get; set; }
        public List<CityDto> CityList { get; set; } = new();
    }
}
