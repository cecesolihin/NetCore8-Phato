using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Commands
{
    public class SubmitRecruitStepGroupCommand : IRequest<string>
    {
        [JsonPropertyName("rec_step_group_code")]
        public string RecStepGroupCode { get; set; }

        [JsonPropertyName("rec_step_group_name")]
        public string RecStepGroupName { get; set; }

        [JsonPropertyName("recruit_step_group_details")]
        public List<RecruitStepGroupDetail> RecruitStepGroupDetails { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }
    }

    public class RecruitStepGroupDetail
    {
        public string RecruitStepCode { get; set; }
        public int Order { get; set; }
        public int? Duration { get; set; }
        public string ProcessPass { get; set; }
    }

}
