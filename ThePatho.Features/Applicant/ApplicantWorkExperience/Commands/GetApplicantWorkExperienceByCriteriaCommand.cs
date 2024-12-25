using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantWorkExperience.DTO;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class GetApplicantWorkExperienceByCriteriaCommand :IRequest<ApplicantWorkExperienceDto>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
