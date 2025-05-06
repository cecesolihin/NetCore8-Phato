using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantAddress.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantAddress.Commands
{
    public class GetApplicantAddressByCriteriaCommand :IRequest<ApiResponse<ApplicantAddressDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
