using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitStep.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.DTO;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class GetRecruitStepGroupDetailByCriteriaCommand : IRequest<ApiResponse<RecruitStepGroupDetailItemDto>>
    {
        [JsonPropertyName("filter_StepGroupCode")]
        public string? FilterStepGroupCode { get; set; }
    }
}
