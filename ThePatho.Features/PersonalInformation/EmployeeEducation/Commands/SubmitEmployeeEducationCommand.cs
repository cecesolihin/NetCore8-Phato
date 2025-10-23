using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeEducation.Commands
{
    public class SubmitEmployeeEducationCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_education_id")]
        public int EmployeeEducationId { get; set; }

        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("edu_level_code")]
        public string EduLevelCode { get; set; } = null!;

        [JsonPropertyName("faculty")]
        public string Faculty { get; set; } = null!;

        [JsonPropertyName("major_code")]
        public string MajorCode { get; set; } = null!;

        [JsonPropertyName("other_major")]
        public string OtherMajor { get; set; } = null!;

        [JsonPropertyName("start_year")]
        public string? StartYear { get; set; }

        [JsonPropertyName("end_year")]
        public string? EndYear { get; set; }

        [JsonPropertyName("gpa")]
        public string Gpa { get; set; } = null!;

        [JsonPropertyName("max_gpa")]
        public string MaxGpa { get; set; } = null!;

        [JsonPropertyName("institution")]
        public string Institution { get; set; } = null!;

        [JsonPropertyName("address")]
        public string Address { get; set; } = null!;

        [JsonPropertyName("city_code")]
        public string CityCode { get; set; } = null!;

        [JsonPropertyName("grad_type_code")]
        public string GradTypeCode { get; set; } = null!;

        [JsonPropertyName("certificate_no")]
        public string CertificateNo { get; set; } = null!;

        [JsonPropertyName("certificate_date")]
        public string? CertificateDate { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

