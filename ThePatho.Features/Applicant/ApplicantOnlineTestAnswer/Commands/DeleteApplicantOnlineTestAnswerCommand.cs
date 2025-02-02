using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;
namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class DeleteApplicantOnlineTestAnswerCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("app_answer_id")]
        public int AppAnswerId { get; set; }
    }
}
