using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocation.DTO;

namespace ThePatho.Features.Organization.WorkLocation.Commands
{
    public class GetWorkLocationByCriteriaCommand : IRequest<ApiResponse<WorkLocationItemDto>>
    {
        [JsonPropertyName("workLocationCode")]
        public string? WorkLocationCode { get; set; }
        [JsonPropertyName("workLocationName")]
        public string? WorkLocationName { get; set; }
        [JsonPropertyName("taxLocationCode")]
        public string? TaxLocationCode { get; set; }
    }
}
