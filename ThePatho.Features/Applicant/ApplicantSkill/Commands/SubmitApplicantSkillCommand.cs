using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantSkill.Commands
{
    public class SubmitApplicantSkillCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; }

        [JsonPropertyName("skill_code")]
        public string SkillCode { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("proficiency_code")]
        public string ProficiencyCode { get; set; }

        [JsonPropertyName("taken_date")]
        public DateTime? TakenDate { get; set; }

        [JsonPropertyName("exp_date")]
        public DateTime? ExpDate { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
