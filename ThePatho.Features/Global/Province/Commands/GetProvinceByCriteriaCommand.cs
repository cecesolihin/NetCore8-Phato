using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Province.DTO;

namespace ThePatho.Features.Global.Province.Commands
{
    public class GetProvinceByCriteriaCommand : IRequest<ApiResponse<ProvinceItemDto>>
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }


        [JsonPropertyName("country")]
        public int? Country { get; set; }

        [JsonPropertyName("abbreviation")]
        public string? Abbreviation { get; set; }

    }
}
