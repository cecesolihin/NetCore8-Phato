using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Announcement.DTO;

namespace ThePatho.Features.Global.Announcement.Commands
{
    public class GetAnnouncementByCriteriaCommand : IRequest<ApiResponse<AnnouncementItemDto>>
    {
        [JsonPropertyName("filter_AnnounceSubject")]
        public string? FilterAnnounceSubject { get; set; }

        [JsonPropertyName("filter_Status")]
        public int? FilterStatus { get; set; }
    }
}
