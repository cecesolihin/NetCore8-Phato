using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
namespace ThePatho.Features.Applicant.ApplicantEducation.Commands
{
    public class DeleteApplicantEducationCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; }

        [JsonPropertyName("edu_level_code")]
        public string EduLevelCode { get; set; }

        [JsonPropertyName("major_code")]
        public string MajorCode { get; set; }
    }
}
