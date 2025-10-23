using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.Rank.Commands
{
    public class DeleteRankCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("rank_code")]
        public string RankCode { get; set; } = null!;
    }
}
