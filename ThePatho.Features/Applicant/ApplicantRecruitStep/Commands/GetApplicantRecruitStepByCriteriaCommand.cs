using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantRecruitStep.DTO;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class GetApplicantRecruitStepByCriteriaCommand :IRequest<ApplicantRecruitStepDto>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
