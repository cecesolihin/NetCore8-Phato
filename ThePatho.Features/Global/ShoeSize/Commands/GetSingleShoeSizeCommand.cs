using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ShoeSize.DTO;

namespace ThePatho.Features.Global.ShoeSize.Commands
{
    public class GetSingleShoeSizeCommand : IRequest<ApiResponse<ShoeSizeDto>>
    {
        [JsonPropertyName("filter_ShoeSizeCode")]
        public string FilterShoeSizeCode { get; set; } = null!;
    }
}
