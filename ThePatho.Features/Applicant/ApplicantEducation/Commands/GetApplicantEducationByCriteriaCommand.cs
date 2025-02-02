using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantEducation.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantEducation.Commands
{
    public class GetApplicantEducationByCriteriaCommand :IRequest<NewApiResponse<ApplicantEducationDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
