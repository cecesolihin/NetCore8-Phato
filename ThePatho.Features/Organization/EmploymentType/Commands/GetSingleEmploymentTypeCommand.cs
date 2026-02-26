using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.EmploymentType.DTO;

namespace ThePatho.Features.Organization.EmploymentType.Commands
{
    public class GetSingleEmploymentTypeCommand : IRequest<ApiResponse<EmploymentTypeDto>>
    {
        [JsonPropertyName("employmentTypeCode")]
        public string EmploymentTypeCode { get; set; } = null!;
    }
}
