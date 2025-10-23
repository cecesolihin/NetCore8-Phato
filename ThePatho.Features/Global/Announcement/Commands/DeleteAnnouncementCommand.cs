using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Announcement.Commands
{
    public class DeleteAnnouncementCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("announcement_id")]
        public int AnnouncementId { get; set; }
    }
}
