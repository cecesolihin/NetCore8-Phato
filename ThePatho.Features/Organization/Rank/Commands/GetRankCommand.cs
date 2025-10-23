using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Rank.DTO;

namespace ThePatho.Features.Organization.Rank.Commands
{
    public class GetRankCommand : IRequest<ApiResponse<RankItemDto>>
    {
        [JsonPropertyName("rank_code")]
        public string RankCode { get; set; } = null!;

        [JsonPropertyName("rank_name")]
        public string RankName { get; set; } = null!;

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
