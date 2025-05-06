using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class SubmitApplicantOnlineTestAnswerCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("app_answer_id")]
        public int AppAnswerId { get; set; }

        [JsonPropertyName("app_result_id")]
        public int AppResultId { get; set; }

        [JsonPropertyName("answer_value")]
        public string AnswerValue { get; set; }

        [JsonPropertyName("weight_point")]
        public int? WeightPoint { get; set; }

        [JsonPropertyName("scoring_code")]
        public string ScoringCode { get; set; }

        [JsonPropertyName("is_correct")]
        public bool? IsCorrect { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
