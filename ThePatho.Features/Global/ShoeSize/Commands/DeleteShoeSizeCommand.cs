using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.ShoeSize.Commands
{
    public class DeleteShoeSizeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("shoe_size_code")]
        public string ShoeSizeCode { get; set; } = null!;
    }
}
