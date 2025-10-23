using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ClothSize.DTO;

namespace ThePatho.Features.Global.ClothSize.Commands
{
    public class GetSingleClothSizeCommand : IRequest<ApiResponse<ClothSizeDto>>
    {
        [JsonPropertyName("filter_ClothSizeName")]
        public string? FilterClothSizeName { get; set; }

        [JsonPropertyName("filter_ClothSizeCode")]
        public string? FilterClothSizeCode { get; set; }

    }
}
