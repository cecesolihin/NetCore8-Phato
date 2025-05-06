using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.Applicant.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.Applicant.Commands
{
    public class GetApplicantByCriteriaCommand :IRequest<ApiResponse<ApplicantDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
