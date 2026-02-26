using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.Rank.Commands
{
    public class SubmitRankCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("rankCode")]
        public string RankCode { get; set; } = null!;

        [JsonPropertyName("rankName")]
        public string RankName { get; set; } = null!;

        [JsonPropertyName("sortOrder")]
        public byte SortOrder { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
