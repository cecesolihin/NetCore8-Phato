using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.Applicant.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.Applicant.Commands
{
    public class GetApplicantByCriteriaCommand :IRequest<NewApiResponse<ApplicantDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
