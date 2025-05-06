using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantRecruitStep.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class GetApplicantRecruitStepByCriteriaCommand :IRequest<ApiResponse<ApplicantRecruitStepDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
