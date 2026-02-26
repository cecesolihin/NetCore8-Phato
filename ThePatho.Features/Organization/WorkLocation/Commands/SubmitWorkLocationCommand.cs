using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.WorkLocation.Commands
{
    public class SubmitWorkLocationCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("workLocationCode")]
        public string WorkLocationCode { get; set; } = null!;

        [JsonPropertyName("workLocationName")]
        public string WorkLocationName { get; set; } = null!;

        [JsonPropertyName("latitude")]
        public decimal? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public decimal? Longitude { get; set; }

        [JsonPropertyName("radius")]
        public int? Radius { get; set; }

        [JsonPropertyName("isActive")]
        public bool? IsActive { get; set; }

        [JsonPropertyName("timeZone")]
        public string? TimeZone { get; set; }

        [JsonPropertyName("taxLocationCode")]
        public string? TaxLocationCode { get; set; }

        [JsonPropertyName("hazardInformation")]
        public string? HazardInformation { get; set; }

        [JsonPropertyName("action")]
        public string? Action { get; set; }
    }
}
