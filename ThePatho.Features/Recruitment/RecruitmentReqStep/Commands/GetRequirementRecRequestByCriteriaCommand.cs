using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;

namespace ThePatho.Features.Recruitment.RecruitmentReqStep.Commands
{ 
    public class GetRecruitmentReqStepByCriteriaCommand :IRequest<ApiResponse<RecruitmentReqStepItemDto>>
    {
        [JsonPropertyName("filter_RequestNo")]
        public string? FilterRequestNo { get; set; }
    }
}
