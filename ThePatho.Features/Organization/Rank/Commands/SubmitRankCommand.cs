using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.Rank.Commands
{
    public class SubmitRankCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("rank_code")]
        public string RankCode { get; set; } = null!;

        [JsonPropertyName("rank_name")]
        public string RankName { get; set; } = null!;

        [JsonPropertyName("order")]
        public byte Order { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
