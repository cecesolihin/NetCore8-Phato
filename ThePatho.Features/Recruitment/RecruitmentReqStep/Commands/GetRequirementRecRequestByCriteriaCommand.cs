using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;

namespace ThePatho.Features.Recruitment.RecruitmentReqStep.Commands
{ 
    public class GetRecruitmentReqStepByCriteriaCommand :IRequest<RecruitmentReqStepItemDto>
    {
        [JsonPropertyName("filter_RequestNo")]
        public string? FilterRequestNo { get; set; }
    }
}
