using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands
{
    public class DeleteApplicantOnlineTestResultCommand : IRequest<bool>
    {
        [JsonPropertyName("app_result_id")]
        public int AppResultId { get; set; }
    }
}
