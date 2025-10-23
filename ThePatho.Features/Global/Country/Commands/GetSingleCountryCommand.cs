using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Country.DTO;

namespace ThePatho.Features.Global.Country.Commands
{
    public class GetSingleCountryCommand : IRequest<ApiResponse<CountryDto>>
    {
        [JsonPropertyName("filter_Name")]
        public string? FilterName { get; set; }

        [JsonPropertyName("filter_CountryId")]
        public int? FilterCountryId { get; set; }

       
    }
}
