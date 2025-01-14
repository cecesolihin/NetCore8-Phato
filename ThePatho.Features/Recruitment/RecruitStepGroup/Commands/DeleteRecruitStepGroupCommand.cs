using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Commands
{
    public class DeleteRecruitStepGroupCommand : IRequest<bool>
    {

        [JsonPropertyName("rec_step_group_code")]
        public string RecStepGroupCode { get; set; }
    }
}
