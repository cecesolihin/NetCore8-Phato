using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ShoeSize.DTO;

namespace ThePatho.Features.Global.ShoeSize.Commands
{
    public class GetShoeSizeByCriteriaCommand : IRequest<ApiResponse<ShoeSizeItemDto>>
    {
        [JsonPropertyName("filter_ShoeSizeName")]
        public string? FilterShoeSizeName { get; set; }

        [JsonPropertyName("filter_ShoeSizeCode")]
        public string? FilterShoeSizeCode { get; set; }

    }
}
