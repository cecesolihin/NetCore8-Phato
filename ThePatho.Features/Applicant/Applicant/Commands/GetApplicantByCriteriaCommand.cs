using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.Applicant.DTO;

namespace ThePatho.Features.Applicant.Applicant.Commands
{
    public class GetApplicantByCriteriaCommand :IRequest<ApplicantDto>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; }
    }
}
