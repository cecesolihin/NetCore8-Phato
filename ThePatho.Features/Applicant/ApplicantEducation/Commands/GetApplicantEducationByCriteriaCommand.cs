using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantEducation.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantEducation.Commands
{
    public class GetApplicantEducationByCriteriaCommand :IRequest<ApiResponse<ApplicantEducationDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
