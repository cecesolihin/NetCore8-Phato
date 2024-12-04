
namespace ThePatho.Features.MasterData.AdsCategory.DTO
{
    public class AdsCategoryDto
    {
        public string AdsCategoryCode { get; set; } = null!;
        public string? AdsCategoryName { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
