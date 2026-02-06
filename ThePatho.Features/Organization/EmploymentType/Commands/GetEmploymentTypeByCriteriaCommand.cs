using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.EmploymentType.DTO;

namespace ThePatho.Features.Organization.EmploymentType.Commands
{
    public class GetEmploymentTypeByCriteriaCommand : IRequest<ApiResponse<EmploymentTypeItemDto>>
    {
        [JsonPropertyName("filter_employment_type_code")]
        public string FilterEmploymentTypeCode { get; set; } = null!;

        [JsonPropertyName("filter_employment_type_name")]
        public string FilterEmploymentTypeName { get; set; } = null!;

        [JsonPropertyName("filter_status")]
        public string FilterStatus { get; set; }

    }
}
