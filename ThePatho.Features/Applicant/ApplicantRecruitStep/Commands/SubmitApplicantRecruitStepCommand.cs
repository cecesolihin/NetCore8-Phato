
using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class SubmitApplicantRecruitStepCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("rec_application_id")]
        public int RecApplicationId { get; set; }

        [JsonPropertyName("recruit_step_code")]
        public string RecruitStepCode { get; set; }

        [JsonPropertyName("score")]
        public string Score { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        [JsonPropertyName("attachment")]
        public string Attachment { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("emp_scorer")]
        public int? EmpScorer { get; set; }

        [JsonPropertyName("schedule_date")]
        public DateTime? ScheduleDate { get; set; }

        [JsonPropertyName("reason_code")]
        public string ReasonCode { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
