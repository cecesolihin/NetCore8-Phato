using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.City.DTO;

namespace ThePatho.Features.Global.City.Commands
{
    public class GetCityByCriteriaCommand : IRequest<ApiResponse<CityItemDto>>
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("cityCode")]
        public string? CityCode { get; set; }

        [JsonPropertyName("provinceId")]
        public int? ProvinceId { get; set; }
    }
}
