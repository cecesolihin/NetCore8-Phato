using MediatR;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantEducation.Commands
{
    public class SubmitApplicantEducationCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; }

        [JsonPropertyName("edu_level_code")]
        public string EduLevelCode { get; set; }

        [JsonPropertyName("major_code")]
        public string MajorCode { get; set; }

        [JsonPropertyName("faculty")]
        public string Faculty { get; set; }

        [JsonPropertyName("start_year")]
        public DateTime StartYear { get; set; }

        [JsonPropertyName("end_year")]
        public DateTime? EndYear { get; set; }

        [JsonPropertyName("gpa")]
        public string GPA { get; set; }

        [JsonPropertyName("max_gpa")]
        public string MaxGPA { get; set; }

        [JsonPropertyName("institution")]
        public string Institution { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("city_code")]
        public string CityCode { get; set; }

        [JsonPropertyName("grad_type_code")]
        public string GradTypeCode { get; set; }

        [JsonPropertyName("certificate_no")]
        public string CertificateNo { get; set; }

        [JsonPropertyName("certificate_date")]
        public DateTime? CertificateDate { get; set; }

        [JsonPropertyName("remark")]
        public string Remark { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
