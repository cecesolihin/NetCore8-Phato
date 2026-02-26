using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.EmploymentType.Commands
{
    public class SubmitEmploymentTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employmentTypeCode")]
        public string EmploymentTypeCode { get; set; } = null!;

        [JsonPropertyName("employmentTypeName")]
        public string EmploymentTypeName { get; set; } = null!;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("sortOrder")]
        public byte SortOrder { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("useEndDate")]
        public bool UseEndDate { get; set; }

        [JsonPropertyName("employmentPeriodMonth")]
        public int? EmploymentPeriodMonth { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("insertedBy")]
        public string? InsertedBy { get; set; }

        [JsonPropertyName("insertedDate")]
        public string? InsertedDate { get; set; }

        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; }

        [JsonPropertyName("modifiedDate")]
        public string? ModifiedDate { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
