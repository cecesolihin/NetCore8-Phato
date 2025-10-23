using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocation.DTO;

namespace ThePatho.Features.Organization.WorkLocation.Commands
{
    public class GetWorkLocationByCriteriaCommand : IRequest<ApiResponse<WorkLocationItemDto>>
    {
        [JsonPropertyName("work_location_code")]
        public string? WorkLocationCode { get; set; }
        [JsonPropertyName("work_location_name")]
        public string? WorkLocationName { get; set; }


        [JsonPropertyName("tax_location_code")]
        public string? TaxLocationCode { get; set; }
    }
}
