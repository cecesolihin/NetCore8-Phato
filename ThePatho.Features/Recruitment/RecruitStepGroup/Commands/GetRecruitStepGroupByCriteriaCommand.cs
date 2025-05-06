using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Commands
{
    public class GetRecruitStepGroupByCriteriaCommand : IRequest<ApiResponse<RecruitStepGroupDto>> 
    {
        [JsonPropertyName("filter_StepGroupCode")]
        public string? FilterStepGroupCode { get; set; }
    }
}
