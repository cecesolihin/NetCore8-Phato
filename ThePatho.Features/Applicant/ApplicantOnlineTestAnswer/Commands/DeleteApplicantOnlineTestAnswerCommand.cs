using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class DeleteApplicantOnlineTestAnswerCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("app_answer_id")]
        public int AppAnswerId { get; set; }
    }
}
