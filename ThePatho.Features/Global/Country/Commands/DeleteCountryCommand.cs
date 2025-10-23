using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Country.Commands
{
    public class DeleteCountryCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("country_id")]
        public int CountryId { get; set; }
    }
}
