
namespace ThePatho.Features.MasterSetting.OnlineTestSetting.DTO
{
    public class OnlineTestSettingDto
    {
        public string OnlineTestCode { get; set; } = null!;
        public string OnlineTestName { get; set; }
        public string TestQuestion { get; set; } = null!;
        public string TestLocation { get; set; } = null!;
        public bool Status { get; set; }
        public string RecruitmentReqNo { get; set; }
        public string OnlineTestDateFrom { get; set; }
        public string OnlineTestDateTo { get; set; }
        public string OnlineTestTimeFrom { get; set; }
        public string OnlineTestTimeTo { get; set; }
        public string ScoringType { get; set; }
        public string EmailTemplate { get; set; }
        public string RecruitmentStep { get; set; }
        public int MinScore { get; set; }
        public int Quota { get; set; }
        public string InsertedBy { get; set; }
        public string InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
    public class OnlineTestSettingItemDto
    {
        public int DataOfRecords { get; set; }
        public List<OnlineTestSettingDto> OnlineTestSettingList { get; set; } = new();
    }

}
