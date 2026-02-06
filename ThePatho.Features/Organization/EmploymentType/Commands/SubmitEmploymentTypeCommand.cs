using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.EmploymentType.Commands
{
    public class SubmitEmploymentTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employment_type_code")]
        public string EmploymentTypeCode { get; set; } = null!;

        [JsonPropertyName("employment_type_name")]
        public string EmploymentTypeName { get; set; } = null!;

        [JsonPropertyName("status")]
        public bool IsActive { get; set; }

        [JsonPropertyName("order")]
        public byte SortOrder { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("use_end_date")]
        public bool UseEndDate { get; set; }

        [JsonPropertyName("employment_period_month")]
        public int? EmploymentPeriodMonth { get; set; }

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("inserted_by")]
        public string? InsertedBy { get; set; }

        [JsonPropertyName("inserted_date")]
        public string? InsertedDate { get; set; }

        [JsonPropertyName("modified_by")]
        public string? ModifiedBy { get; set; }

        [JsonPropertyName("modified_date")]
        public string? ModifiedDate { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
