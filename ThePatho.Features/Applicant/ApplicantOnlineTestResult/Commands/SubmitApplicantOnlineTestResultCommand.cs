using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands
{
    public class SubmitApplicantOnlineTestResultCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("app_result_id")]
        public int AppResultId { get; set; } // 0 for ADD, non-zero for EDIT

        [JsonPropertyName("online_test_code")]
        public string OnlineTestCode { get; set; }

        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; }

        [JsonPropertyName("questionnaire_code")]
        public string QuestionnaireCode { get; set; }

        [JsonPropertyName("questionnaire_name")]
        public string QuestionnaireName { get; set; }

        [JsonPropertyName("answer_method")]
        public string AnswerMethod { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }

        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("end_date")]
        public DateTime? EndDate { get; set; }

        [JsonPropertyName("submit_date")]
        public DateTime? SubmitDate { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
