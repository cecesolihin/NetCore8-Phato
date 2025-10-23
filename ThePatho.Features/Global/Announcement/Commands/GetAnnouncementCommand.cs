using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Announcement.DTO;

namespace ThePatho.Features.Global.Announcement.Commands
{
    public class GetAnnouncementCommand : IRequest<ApiResponse<AnnouncementItemDto>>
    {
        [JsonPropertyName("filter_AnnounceSubject")]
        public string? FilterAnnounceSubject { get; set; }

        [JsonPropertyName("filter_Status")]
        public int? FilterStatus { get; set; }

        [JsonPropertyName("filter_AnnounceContent")]
        public string? FilterAnnounceContent { get; set; }

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
