using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class GetOnlineTestSettingCommand: IRequest<ApiResponse<OnlineTestSettingItemDto>>
    {
        [JsonPropertyName("filter_OnlineTestCode")]
        public string? FilterOnlineTestCode { get; set; }

        [JsonPropertyName("filter_OnlineTestName")]
        public string? FilterOnlineTestName { get; set; }

        [JsonPropertyName("filter_TestQuestion")]
        public string? FilterTestQuestion { get; set; }

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
