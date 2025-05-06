using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class DeleteApplicantRecruitStepCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("rec_application_id")]
        public int RecApplicationId { get; set; }

        [JsonPropertyName("recruit_step_code")]
        public string RecruitStepCode { get; set; }
    }
}
