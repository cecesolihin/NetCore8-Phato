using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TimeZone.DTO;

namespace ThePatho.Features.Global.TimeZone.Commands
{
    public class GetTimeZoneCommand : IRequest<ApiResponse<TimeZoneItemDto>>
    {
        [JsonPropertyName("filter_TimeZoneName")]
        public string? FilterTimeZoneName { get; set; }

        [JsonPropertyName("filter_TimeZoneCode")]
        public string? FilterTimeZoneCode { get; set; }

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
