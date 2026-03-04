using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.City.Commands
{
    public class SubmitCityCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("city_id")]
        public int? CityId { get; set; }

        [JsonPropertyName("city_code")]
        public string CityCode { get; set; } = null!;

        [JsonPropertyName("province_id")]
        public int ProvinceId { get; set; }

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
