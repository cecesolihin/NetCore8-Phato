using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ClothSize.DTO;

namespace ThePatho.Features.Global.ClothSize.Commands
{
    public class GetClothSizeCommand : IRequest<ApiResponse<ClothSizeItemDto>>
    {
        [JsonPropertyName("filter_ClothSizeName")]
        public string? FilterClothSizeName { get; set; }

        [JsonPropertyName("filter_ClothSizeCode")]
        public string? FilterClothSizeCode { get; set; }

        [JsonPropertyName("sortBy")]
        [DefaultValue("InsertedDate")]
        public string? SortBy { get; set; } = "InsertedDate";

        [JsonPropertyName("orderBy")]
        [DefaultValue("DESC")]
        public string? OrderBy { get; set; } = "DESC";

        [JsonPropertyName("pageNumber")]
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;

        [JsonPropertyName("pageSize")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}
