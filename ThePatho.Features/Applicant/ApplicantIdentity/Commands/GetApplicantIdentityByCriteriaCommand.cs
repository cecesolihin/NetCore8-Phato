using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class GetApplicantIdentityByCriteriaCommand :IRequest<ApplicantIdentityDto>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
