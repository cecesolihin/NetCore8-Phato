using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Applicant.ApplicantSkill.Commands
{
    public class DeleteApplicantSkillCommand : IRequest<bool>
    {
        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; }

        [JsonPropertyName("skill_code")]
        public string SkillCode { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }
    }
}
