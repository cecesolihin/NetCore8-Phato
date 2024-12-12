
namespace ThePatho.Features.MasterData.AdsCategory.DTO
{
    public class AdsCategoryItemDto
    {
        public int DataOfRecords { get; set; }
        public List<AdsCategoryDto> AdsCategoryList { get; set; } = new();
    }
    public class AdsCategoryDto
    {
        public string AdsCategoryCode { get; set; }
        public string AdsCategoryName { get; set; }
        public string InsertedBy { get; set; }
        public string InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
}
