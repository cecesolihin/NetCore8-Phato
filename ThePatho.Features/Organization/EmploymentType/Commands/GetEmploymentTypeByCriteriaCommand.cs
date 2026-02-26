using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.EmploymentType.DTO;

namespace ThePatho.Features.Organization.EmploymentType.Commands
{
    public class GetEmploymentTypeByCriteriaCommand : IRequest<ApiResponse<EmploymentTypeItemDto>>
    {
        [JsonPropertyName("employmentTypeCode")]
        public string? EmploymentTypeCode { get; set; }

        [JsonPropertyName("employmentTypeName")]
        public string? EmploymentTypeName { get; set; }

    }
}
