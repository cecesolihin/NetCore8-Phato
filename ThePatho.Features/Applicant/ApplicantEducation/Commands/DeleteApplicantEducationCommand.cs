using MediatR;
using System.Text.Json.Serialization;
namespace ThePatho.Features.Applicant.ApplicantEducation.Commands
{
    public class DeleteApplicantEducationCommand : IRequest<bool>
    {
        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; }

        [JsonPropertyName("edu_level_code")]
        public string EduLevelCode { get; set; }

        [JsonPropertyName("major_code")]
        public string MajorCode { get; set; }
    }
}
