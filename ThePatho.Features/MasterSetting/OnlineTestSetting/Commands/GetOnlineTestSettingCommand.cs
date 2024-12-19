using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class GetOnlineTestSettingCommand: IRequest<OnlineTestSettingItemDto>
    {
        [JsonPropertyName("filter_OnlineTestCode")]
        public string? FilterOnlineTestCode { get; set; }
        [JsonPropertyName("filter_OnlineTestName")]
        public string? FilterOnlineTestName { get; set; }
        [JsonPropertyName("filter_TestQuestion")]
        public string? FilterTestQuestion { get; set; }

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
