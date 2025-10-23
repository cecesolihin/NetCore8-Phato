
namespace ThePatho.Domain.Models.Global
{
    public class TaxStatus
    {
        public string TaxStatusCode { get; set; } = null!;
        public string TaxStatusName { get; set; } = null!;
        public string Married { get; set; } = null!;
        public byte TotalDependents { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
