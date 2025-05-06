using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands
{
    public class GetApplicantOnlineTestResultByCriteriaCommand :IRequest<ApiResponse<ApplicantOnlineTestResultDto>> 
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; }
    }
}
