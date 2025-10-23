using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.RomanianSize.Commands
{
    public class DeleteRomanianSizeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("romanian_size_id")]
        public int RomanianSizeId { get; set; }
    }
}
