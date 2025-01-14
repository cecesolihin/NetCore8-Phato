using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class DeleteRecruitStepCommand : IRequest<bool>
    {
        [JsonPropertyName("recruitStepCode")]
        public string RecruitStepCode { get; set; }
    }
}
