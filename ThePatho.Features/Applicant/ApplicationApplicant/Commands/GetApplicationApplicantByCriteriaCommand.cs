using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicationApplicant.DTO;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Commands
{
    public class GetApplicationApplicantByCriteriaCommand :IRequest<ApplicationApplicantDto>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
