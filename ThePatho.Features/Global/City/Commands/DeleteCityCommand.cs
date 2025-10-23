using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.City.Commands
{
    public class DeleteCityCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("city_id")]
        public int CityId { get; set; }
    }
}
