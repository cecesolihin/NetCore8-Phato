using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.City.DTO;

namespace ThePatho.Features.Global.City.Commands
{
    public class GetSingleCityCommand : IRequest<ApiResponse<CityDto>>
    {
        [JsonPropertyName("filter_CityId")]
        public int FilterCityId { get; set; }
    }
}
