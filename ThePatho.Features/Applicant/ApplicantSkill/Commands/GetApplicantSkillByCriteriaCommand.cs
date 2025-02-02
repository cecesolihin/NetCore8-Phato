using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantSkill.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantSkill.Commands
{
    public class GetApplicantSkillByCriteriaCommand :IRequest<NewApiResponse<ApplicantSkillDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
