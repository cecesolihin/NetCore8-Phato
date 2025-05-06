using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantSkill.Commands
{
    public class DeleteApplicantSkillCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; }

        [JsonPropertyName("skill_code")]
        public string SkillCode { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }
    }
}
