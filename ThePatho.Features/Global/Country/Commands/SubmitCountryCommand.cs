using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Country.Commands
{
    public class SubmitCountryCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("country_id")]
        public int? CountryId { get; set; }

        [JsonPropertyName("SortOrder")]
        public int? Sort { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("numeric_iso_code")]
        public int NumericIsoCode { get; set; }

        [JsonPropertyName("three_letter_iso_code")]
        public string? ThreeLetterIsoCode { get; set; }

        [JsonPropertyName("two_letter_iso_code")]
        public string? TwoLetterIsoCode { get; set; }

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
