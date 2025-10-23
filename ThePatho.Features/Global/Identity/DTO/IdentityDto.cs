namespace ThePatho.Features.Global.Identity.DTO
{
    public class IdentityDto
    {
        public string IdentityCode { get; set; } = null!;
        public string IdentityName { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public bool ShowInDashboard { get; set; }
        public int? DefaultRange { get; set; }
    }

    public class IdentityItemDto
    {
        public int DataOfRecords { get; set; }
        public List<IdentityDto> IdentityList { get; set; } = new();
    }
}

