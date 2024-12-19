using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.MasterData.AdsMedia.DTO;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetAdsMediaCommand: IRequest<AdsMediaItemDto>
    {
        [JsonPropertyName("filter_AdsCode")]
        public string? FilterAdsCode { get; set; }
        [JsonPropertyName("filter_AdsName")]
        public string? FilterAdsName { get; set; }
        [JsonPropertyName("filter_AdsCategoryCode")]
        public string? FilterAdsCategoryCode { get; set; }
        [JsonPropertyName("sortBy")]
        public string? SortBy { get; set; } = "InsertedDate";
        [JsonPropertyName("orderBy")]
        public string? OrderBy { get; set; } = "DESC";
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; } = 0;
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = 10;
    }
}
