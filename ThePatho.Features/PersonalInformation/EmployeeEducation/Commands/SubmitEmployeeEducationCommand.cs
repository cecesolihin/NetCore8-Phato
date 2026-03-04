using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeEducation.Commands
{
    public class SubmitEmployeeEducationCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employeeEducationId")]
        public int EmployeeEducationId { get; set; }

        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("eduLevelCode")]
        public string EduLevelCode { get; set; } = null!;

        [JsonPropertyName("faculty")]
        public string Faculty { get; set; } = null!;

        [JsonPropertyName("majorCode")]
        public string MajorCode { get; set; } = null!;

        [JsonPropertyName("otherMajor")]
        public string OtherMajor { get; set; } = null!;

        [JsonPropertyName("startYear")]
        public string? StartYear { get; set; }

        [JsonPropertyName("endYear")]
        public string? EndYear { get; set; }

        [JsonPropertyName("gpa")]
        public string Gpa { get; set; } = null!;

        [JsonPropertyName("maxGpa")]
        public string MaxGpa { get; set; } = null!;

        [JsonPropertyName("institution")]
        public string Institution { get; set; } = null!;

        [JsonPropertyName("address")]
        public string Address { get; set; } = null!;

        [JsonPropertyName("cityCode")]
        public string CityCode { get; set; } = null!;

        [JsonPropertyName("gradTypeCode")]
        public string GradTypeCode { get; set; } = null!;

        [JsonPropertyName("certificateNo")]
        public string CertificateNo { get; set; } = null!;

        [JsonPropertyName("certificateDate")]
        public string? CertificateDate { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

