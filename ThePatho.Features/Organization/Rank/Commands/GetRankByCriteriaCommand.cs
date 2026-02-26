using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Rank.DTO;

namespace ThePatho.Features.Organization.Rank.Commands
{
    public class GetRankByCriteriaCommand : IRequest<ApiResponse<RankItemDto>>
    {
        [JsonPropertyName("rankCode")]
        public string? RankCode { get; set; }

        [JsonPropertyName("rankName")]
        public string? RankName { get; set; }
    }
}
