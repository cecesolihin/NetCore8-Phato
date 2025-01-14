using MediatR;
using System.Text.Json.Serialization;
namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class DeleteApplicantOnlineTestAnswerCommand : IRequest<bool>
    {
        [JsonPropertyName("app_answer_id")]
        public int AppAnswerId { get; set; }
    }
}
