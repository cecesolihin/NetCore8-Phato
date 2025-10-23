using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RomanianSize.DTO;

namespace ThePatho.Features.Global.RomanianSize.Commands
{
    public class GetSingleRomanianSizeCommand : IRequest<ApiResponse<RomanianSizeDto>>
    {
        [JsonPropertyName("filter_RomanianSizeId")]
        public int FilterRomanianSizeId { get; set; }
    }
}
