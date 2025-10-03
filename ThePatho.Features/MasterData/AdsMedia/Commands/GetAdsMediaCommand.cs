using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsMedia.DTO;

namespace ThePatho.Features.MasterData.AdsMedia.Commands
{
    public class GetAdsMediaCommand: IRequest<ApiResponse<AdsMediaItemDto>>
    {
        [JsonPropertyName("filter_AdsCode")]
        public string? FilterAdsCode { get; set; }

        [JsonPropertyName("filter_AdsName")]
        public string? FilterAdsName { get; set; } 

        [JsonPropertyName("filter_AdsCategoryCode")]
        public string? FilterAdsCategoryCode { get; set; }

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
