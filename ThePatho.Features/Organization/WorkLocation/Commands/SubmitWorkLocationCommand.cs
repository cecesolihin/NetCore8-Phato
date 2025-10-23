using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.WorkLocation.Commands
{
    public class SubmitWorkLocationCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("work_location_code")]
        public string WorkLocationCode { get; set; } = null!;

        [JsonPropertyName("work_location_name")]
        public string WorkLocationName { get; set; } = null!;

        [JsonPropertyName("latitude")]
        public decimal? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public decimal? Longitude { get; set; }

        [JsonPropertyName("radius")]
        public int? Radius { get; set; }

        [JsonPropertyName("is_active")]
        public bool? IsActive { get; set; }

        [JsonPropertyName("time_zone")]
        public string? TimeZone { get; set; }

        [JsonPropertyName("tax_location_code")]
        public string? TaxLocationCode { get; set; }

        [JsonPropertyName("hazard_information")]
        public string? HazardInformation { get; set; }

        [JsonPropertyName("action")]
        public string? Action { get; set; }
    }
}
