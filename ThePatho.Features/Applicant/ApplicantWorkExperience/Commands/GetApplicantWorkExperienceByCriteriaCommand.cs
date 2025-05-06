using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantWorkExperience.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class GetApplicantWorkExperienceByCriteriaCommand :IRequest<ApiResponse<ApplicantWorkExperienceDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
