using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class GetApplicantOnlineTestAnswerByCriteriaCommand :IRequest<NewApiResponse<ApplicantOnlineTestAnswerDto>>
    {
        [JsonPropertyName("filter_AppResultId")]
        public string? FilterAppResultId { get; set; } 
    }
}
