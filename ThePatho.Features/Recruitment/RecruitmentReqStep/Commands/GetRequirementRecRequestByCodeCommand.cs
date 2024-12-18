using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;

namespace ThePatho.Features.Recruitment.RecruitmentReqStep.Commands
{
    public class GetRecruitmentReqStepByCodeCommand :IRequest<RecruitmentReqStepItemDto>
    {
        [JsonPropertyName("filter_RequestNo")]
        public string? FilterRequestNo { get; set; }
    }
}
