using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands
{
    public class DeleteApplicantOnlineTestResultCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("app_result_id")]
        public int AppResultId { get; set; }
    }
}
