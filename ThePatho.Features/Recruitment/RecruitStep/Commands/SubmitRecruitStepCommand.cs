using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class SubmitRecruitStepCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("recruit_step_code")]
        public string RecruitStepCode { get; set; }

        [JsonPropertyName("recruit_step_name")]
        public string RecruitStepName { get; set; }

        [JsonPropertyName("use_failed_reason")]
        public bool UseFailedReason { get; set; }

        [JsonPropertyName("min_score")]
        public double MinScore { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
