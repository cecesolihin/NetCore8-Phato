using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Province.DTO;

namespace ThePatho.Features.Global.Province.Commands
{
    public class GetProvinceByCriteriaCommand : IRequest<ApiResponse<ProvinceItemDto>>
    {
        [JsonPropertyName("filter_Name")]
        public string? FilterName { get; set; }


        [JsonPropertyName("filter_Country")]
        public int? FilterCountry { get; set; }

        [JsonPropertyName("filter_Abbreviation")]
        public string? FilterAbbreviation { get; set; }

    }
}
