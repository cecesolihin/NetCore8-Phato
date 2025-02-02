using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class GetApplicantIdentityByCriteriaCommand :IRequest<NewApiResponse<ApplicantIdentityDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
