namespace ThePatho.Domain.Models.Global
{
    public class Identity
    {
        public string IdentityCode { get; set; } = null!;
        public string IdentityName { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool ShowInDashboard { get; set; }
        public int? DefaultRange { get; set; }
    }

}

