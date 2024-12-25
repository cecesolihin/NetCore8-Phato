using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.DTO;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands
{
    public class GetApplicantOnlineTestResultByCriteriaCommand :IRequest<ApplicantOnlineTestResultDto> 
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; }
    }
}
