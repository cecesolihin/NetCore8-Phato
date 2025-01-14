using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class DeleteApplicantRecruitStepCommand : IRequest<bool>
    {
        [JsonPropertyName("rec_application_id")]
        public int RecApplicationId { get; set; }

        [JsonPropertyName("recruit_step_code")]
        public string RecruitStepCode { get; set; }
    }
}
