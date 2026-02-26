using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Rank.DTO;

namespace ThePatho.Features.Organization.Rank.Commands
{
    public class GetSingleRankCommand : IRequest<ApiResponse<RankDto>>
    {
        [JsonPropertyName("rankCode")]
        public string RankCode { get; set; } = null!;
    }
}
