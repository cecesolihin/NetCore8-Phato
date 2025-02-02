using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantWorkExperience.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class GetApplicantWorkExperienceByCriteriaCommand :IRequest<NewApiResponse<ApplicantWorkExperienceDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
