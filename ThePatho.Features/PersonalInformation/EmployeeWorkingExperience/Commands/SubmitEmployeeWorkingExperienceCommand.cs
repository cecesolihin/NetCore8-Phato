using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Commands
{
    public class SubmitEmployeeWorkingExperienceCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("emp_work_experience_id")]
        public int EmpWorkExperienceId { get; set; }

        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("start_working")]
        public string StartWorking { get; set; } = null!;

        [JsonPropertyName("end_working")]
        public string? EndWorking { get; set; }

        [JsonPropertyName("employment_type_code")]
        public string EmploymentTypeCode { get; set; } = null!;

        [JsonPropertyName("organization")]
        public string Organization { get; set; } = null!;

        [JsonPropertyName("company")]
        public string Company { get; set; } = null!;

        [JsonPropertyName("business_field")]
        public string BusinessField { get; set; } = null!;

        [JsonPropertyName("address")]
        public string Address { get; set; } = null!;

        [JsonPropertyName("city_code")]
        public int? CityId { get; set; } = null;

        [JsonPropertyName("job_level")]
        public string JobLevel { get; set; } = null!;

        [JsonPropertyName("job_description")]
        public string JobDescription { get; set; } = null!;

        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [JsonPropertyName("website")]
        public string? Website { get; set; }

        [JsonPropertyName("reference_name")]
        public string? ReferenceName { get; set; }

        [JsonPropertyName("reference_phone")]
        public string? ReferencePhone { get; set; }

        [JsonPropertyName("reference_email")]
        public string? ReferenceEmail { get; set; }

        [JsonPropertyName("currency_code21")]
        public string? CurrencyCode21 { get; set; }

        [JsonPropertyName("currency_code15")]
        public string? CurrencyCode15 { get; set; }

        [JsonPropertyName("pph_a21")]
        public double? PphA21 { get; set; }

        [JsonPropertyName("pph_a15")]
        public double? PphA15 { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

