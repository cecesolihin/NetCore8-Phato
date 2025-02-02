using MediatR;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class SubmitOnlineTestSettingCommand : IRequest<ApiResponse>
    {
        [JsonProperty("online_test_code")]
        public string OnlineTestCode { get; set; }

        [JsonProperty("online_test_name")]
        public string OnlineTestName { get; set; }

        [JsonProperty("test_question")]
        public string TestQuestion { get; set; }

        [JsonProperty("test_location")]
        public string TestLocation { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("recruitment_req_no")]
        public string RecruitmentReqNo { get; set; }

        [JsonProperty("online_test_date_from")]
        public DateTime OnlineTestDateFrom { get; set; }

        [JsonProperty("online_test_date_to")]
        public DateTime OnlineTestDateTo { get; set; }

        [JsonProperty("online_test_time_from")]
        public TimeSpan OnlineTestTimeFrom { get; set; }

        [JsonProperty("online_test_time_to")]
        public TimeSpan OnlineTestTimeTo { get; set; }

        [JsonProperty("scoring_type")]
        public string ScoringType { get; set; }

        [JsonProperty("email_template")]
        public string EmailTemplate { get; set; }

        [JsonProperty("recruitment_step")]
        public string RecruitmentStep { get; set; }

        [JsonProperty("min_score")]
        public int MinScore { get; set; }

        [JsonProperty("quota")]
        public int Quota { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }
}
