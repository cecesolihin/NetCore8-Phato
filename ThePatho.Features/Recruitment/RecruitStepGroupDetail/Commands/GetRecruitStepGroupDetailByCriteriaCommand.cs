using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Recruitment.RecruitStep.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.DTO;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class GetRecruitStepGroupDetailByCriteriaCommand : IRequest<RecruitStepGroupDetailItemDto>
    {
        [JsonPropertyName("filter_StepGroupCode")]
        public string? FilterStepGroupCode { get; set; }
    }
}
