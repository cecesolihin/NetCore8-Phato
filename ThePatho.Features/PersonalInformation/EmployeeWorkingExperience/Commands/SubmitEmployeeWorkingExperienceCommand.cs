using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Commands
{
    public class SubmitEmployeeWorkingExperienceCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("empWorkExperienceId")]
        public int EmpWorkExperienceId { get; set; }

        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("startWorking")]
        public string StartWorking { get; set; } = null!;

        [JsonPropertyName("endWorking")]
        public string? EndWorking { get; set; }

        [JsonPropertyName("employmentTypeCode")]
        public string EmploymentTypeCode { get; set; } = null!;

        [JsonPropertyName("organization")]
        public string Organization { get; set; } = null!;

        [JsonPropertyName("company")]
        public string Company { get; set; } = null!;

        [JsonPropertyName("businessField")]
        public string BusinessField { get; set; } = null!;

        [JsonPropertyName("address")]
        public string Address { get; set; } = null!;

        [JsonPropertyName("cityId")]
        public int? CityId { get; set; }

        [JsonPropertyName("jobLevel")]
        public string JobLevel { get; set; } = null!;

        [JsonPropertyName("jobDescription")]
        public string JobDescription { get; set; } = null!;

        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [JsonPropertyName("website")]
        public string? Website { get; set; }

        [JsonPropertyName("referenceName")]
        public string? ReferenceName { get; set; }

        [JsonPropertyName("referencePhone")]
        public string? ReferencePhone { get; set; }

        [JsonPropertyName("referenceEmail")]
        public string? ReferenceEmail { get; set; }

        [JsonPropertyName("currencyCode21")]
        public string? CurrencyCode21 { get; set; }

        [JsonPropertyName("currencyCode15")]
        public string? CurrencyCode15 { get; set; }

        [JsonPropertyName("pphA21")]
        public double? PphA21 { get; set; }

        [JsonPropertyName("pphA15")]
        public double? PphA15 { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

