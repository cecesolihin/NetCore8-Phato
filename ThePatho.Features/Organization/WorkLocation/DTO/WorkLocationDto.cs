namespace ThePatho.Features.Organization.WorkLocation.DTO
{
    public class WorkLocationDto
    {
        public string WorkLocationCode { get; set; } = null!;
        public string WorkLocationName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? Radius { get; set; }
        public bool? IsActive { get; set; }
        public string? TimeZone { get; set; }
        public string? TaxLocationCode { get; set; }
        public string? HazardInformation { get; set; }
    }

    public class WorkLocationItemDto
    {
        public int DataOfRecords { get; set; }
        public List<WorkLocationDto> WorkLocationList { get; set; } = new();
    }
}
