using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantSkill.DTO;

namespace ThePatho.Features.Applicant.ApplicantSkill.Commands
{
    public class GetApplicantSkillByCriteriaCommand :IRequest<ApplicantSkillDto>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
