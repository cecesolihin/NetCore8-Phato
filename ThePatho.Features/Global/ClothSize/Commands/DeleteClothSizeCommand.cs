using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.ClothSize.Commands
{
    public class DeleteClothSizeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("cloth_size_code")]
        public string ClothSizeCode { get; set; } = null!;
    }
}
