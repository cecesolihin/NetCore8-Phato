using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using System.ComponentModel;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetAdsCategoryCommand: IRequest<ApiResponse<AdsCategoryItemDto>>
    {
        [JsonPropertyName("filter_AdsCategoryCode")]
        public string? FilterAdsCategoryCode { get; set; }

        [JsonPropertyName("filter_AdsCategoryName")]
        public string? FilterAdsCategoryName { get; set; }

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
