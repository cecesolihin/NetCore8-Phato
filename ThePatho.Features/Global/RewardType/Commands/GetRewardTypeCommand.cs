using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RewardType.DTO;

namespace ThePatho.Features.Global.RewardType.Commands
{
    public class GetRewardTypeCommand : IRequest<ApiResponse<RewardTypeItemDto>>
    {
        [JsonPropertyName("filter_RewardTypeName")]
        public string? FilterRewardTypeName { get; set; }

        [JsonPropertyName("filter_RewardTypeCode")]
        public string? FilterRewardTypeCode { get; set; }

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
