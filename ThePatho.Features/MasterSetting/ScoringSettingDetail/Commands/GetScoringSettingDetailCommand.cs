using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class GetScoringSettingDetailCommand : IRequest<ApiResponse<ScoringSettingDetailItemDto>>
    {
        [JsonPropertyName("filter_ScoringCode")]
        public string? FilterScoringCode { get; set; }

        [JsonPropertyName("filter_ScoringName")]
        public string? FilterScoringName { get; set; }

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
