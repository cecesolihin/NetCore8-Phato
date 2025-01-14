
namespace ThePatho.Domain.Models.Recruitment
{
    public class MPP
    {
        public string MppNo { get; set; } 
        public string? MppYear { get; set; }
        public string PeriodCode { get; set; } = string.Empty;
        public string? Remarks { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
