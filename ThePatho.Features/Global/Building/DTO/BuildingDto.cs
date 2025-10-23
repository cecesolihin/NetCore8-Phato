namespace ThePatho.Features.Global.Building.DTO
{
    public class BuildingDto
    {
        public string BuildingCode { get; set; } = null!;
        public string BuildingName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class BuildingItemDto
    {
        public int DataOfRecords { get; set; }
        public List<BuildingDto> BuildingList { get; set; } = new();
    }
}
