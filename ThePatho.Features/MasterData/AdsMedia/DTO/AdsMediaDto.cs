
using ThePatho.Features.MasterData.AdsCategory.DTO;

namespace ThePatho.Features.MasterData.AdsMedia.DTO
{
    public class AdsMediaDto
    {
        public string AdsCode { get; set; } = null!;
        public string? AdsName { get; set; }
        public string AdsCategoryCode { get; set; } = null!;
        public string? Phone { get; set; }
        public string? ContactPerson { get; set; }
        public string? Remarks { get; set; }
        public bool UseRecruitmentFee { get; set; }
        public string? RecruitmentFee { get; set; }
        public string? RecruitmentFee2 { get; set; }
        public string? RecruitmentFee3 { get; set; }
        public string? InsertedBy { get; set; }
        public string InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
    public class AdsMediaItemDto
    {
        public int DataOfRecords { get; set; }
        public List<AdsMediaDto> AdsMediaList { get; set; }
    }
}
