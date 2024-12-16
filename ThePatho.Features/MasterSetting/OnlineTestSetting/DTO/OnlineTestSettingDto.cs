
using ThePatho.Features.MasterSetting.QuestionSetting.DTO;

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
        public DateTime OnlineTestDateFrom { get; set; }
        public DateTime OnlineTestDateTo { get; set; }
        public TimeSpan OnlineTestTimeFrom { get; set; }
        public TimeSpan OnlineTestTimeTo { get; set; }
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
