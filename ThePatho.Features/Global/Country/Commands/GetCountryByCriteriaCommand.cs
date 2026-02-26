using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Country.DTO;

namespace ThePatho.Features.Global.Country.Commands
{
    public class GetCountryByCriteriaCommand : IRequest<ApiResponse<CountryItemDto>>
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("numericIsoCode")]
        public int? NumericIsoCode { get; set; }

        [JsonPropertyName("threeLetterIsoCode")]
        public string? ThreeLetterIsoCode { get; set; }

        [JsonPropertyName("twoLetterIsoCode")]
        public string? TwoLetterIsoCode { get; set; }


    }
}
