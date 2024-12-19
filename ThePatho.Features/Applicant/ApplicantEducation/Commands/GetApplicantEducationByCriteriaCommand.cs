using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantEducation.DTO;

namespace ThePatho.Features.Applicant.ApplicantEducation.Commands
{
    public class GetApplicantEducationByCriteriaCommand :IRequest<ApplicantEducationDto>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; }
    }
}
