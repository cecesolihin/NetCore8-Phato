using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantAddress.DTO;

namespace ThePatho.Features.Applicant.ApplicantAddress.Commands
{
    public class GetApplicantAddressByCriteriaCommand :IRequest<ApplicantAddressDto>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; }
    }
}
