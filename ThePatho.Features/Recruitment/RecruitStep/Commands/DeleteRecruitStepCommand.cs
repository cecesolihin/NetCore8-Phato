using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class DeleteRecruitStepCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("recruitStepCode")]
        public string RecruitStepCode { get; set; }
    }
}
