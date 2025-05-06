using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class GetApplicantOnlineTestAnswerByCriteriaCommand :IRequest<ApiResponse<ApplicantOnlineTestAnswerDto>>
    {
        [JsonPropertyName("filter_AppResultId")]
        public string? FilterAppResultId { get; set; } 
    }
}
