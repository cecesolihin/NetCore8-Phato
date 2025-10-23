using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.City.DTO;

namespace ThePatho.Features.Global.City.Commands
{
    public class GetCityByCriteriaCommand : IRequest<ApiResponse<CityItemDto>>
    {
        [JsonPropertyName("filter_Name")]
        public string? FilterName { get; set; }

        [JsonPropertyName("filter_CityCode")]
        public string? FilterCityCode { get; set; }

        [JsonPropertyName("filter_ProvinceId")]
        public int FilterProvinceId { get; set; }
    }
}
