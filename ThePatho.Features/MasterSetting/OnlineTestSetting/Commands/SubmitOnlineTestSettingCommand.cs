using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class SubmitOnlineTestSettingCommand : IRequest<string>
    {
        public string OnlineTestCode { get; set; }
        public string OnlineTestName { get; set; }
        public string TestQuestion { get; set; }
        public string TestLocation { get; set; }
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
        public string Action { get; set; }
    }
}
