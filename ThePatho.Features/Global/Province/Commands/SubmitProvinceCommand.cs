using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Province.Commands
{
    public class SubmitProvinceCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("province_id")]
        public int? ProvinceId { get; set; }

        [JsonPropertyName("abbreviation")]
        public string? Abbreviation { get; set; }

        [JsonPropertyName("country_id")]
        public int CountryId { get; set; }

        [JsonPropertyName("SortOrder")]
        public int? Sort { get; set; }

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
