using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantSkill.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantSkill.Commands
{
    public class GetApplicantSkillByCriteriaCommand :IRequest<ApiResponse<ApplicantSkillDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
