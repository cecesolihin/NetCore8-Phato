using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitStep.DTO;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class GetRecruitStepByCriteriaCommand :IRequest<ApiResponse<RecruitStepDto>> 
    {
        [JsonPropertyName("filter_StepCode")]
        public string? FilterStepCode { get; set; }
    }
}
