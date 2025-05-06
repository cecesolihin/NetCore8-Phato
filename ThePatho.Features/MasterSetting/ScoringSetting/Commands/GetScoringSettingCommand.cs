using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class GetScoringSettingCommand : IRequest<ApiResponse<ScoringSettingItemDto>>
    {
        [JsonPropertyName("filter_ScoringCode")]
        public string? FilterScoringCode { get; set; }
        [JsonPropertyName("filter_ScoringName")]
        public string? FilterScoringName { get; set; }

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
