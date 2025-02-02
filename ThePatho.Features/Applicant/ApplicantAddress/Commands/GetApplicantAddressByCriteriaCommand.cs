using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantAddress.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantAddress.Commands
{
    public class GetApplicantAddressByCriteriaCommand :IRequest<NewApiResponse<ApplicantAddressDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
