using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Rank.DTO;

namespace ThePatho.Features.Organization.Rank.Commands
{
    public class GetRankByCriteriaCommand : IRequest<ApiResponse<RankItemDto>>
    {
        [JsonPropertyName("rank_code")]
        public string RankCode { get; set; } = null!;

        [JsonPropertyName("rank_name")]
        public string? RankName { get; set; }
    }
}
