using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Country.DTO;

namespace ThePatho.Features.Global.Country.Commands
{
    public class GetCountryByCriteriaCommand : IRequest<ApiResponse<CountryItemDto>>
    {
        [JsonPropertyName("filter_Name")]
        public string? FilterName { get; set; }

        [JsonPropertyName("filter_NumericIsoCode")]
        public int? FilterNumericIsoCode { get; set; }

        [JsonPropertyName("filter_ThreeLetterIsoCode")]
        public string? FilterThreeLetterIsoCode { get; set; }

        [JsonPropertyName("filter_TwoLetterIsoCode")]
        public string? FilterTwoLetterIsoCode { get; set; }


    }
}
