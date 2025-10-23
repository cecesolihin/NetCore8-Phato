using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Announcement.DTO;

namespace ThePatho.Features.Global.Announcement.Commands
{
    public class GetSingleAnnouncementCommand : IRequest<ApiResponse<AnnouncementDto>>
    {
        [JsonPropertyName("filter_AnnouncementId")]
        public int FilterAnnouncementId { get; set; }
    }
}
