using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicationApplicant.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Commands
{
    public class GetApplicationApplicantByCriteriaCommand :IRequest<ApiResponse<ApplicationApplicantDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
