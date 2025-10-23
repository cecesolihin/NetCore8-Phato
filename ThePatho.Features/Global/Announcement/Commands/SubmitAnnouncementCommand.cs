using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Announcement.Commands
{
    public class SubmitAnnouncementCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("announcement_id")]
        public int? AnnouncementId { get; set; }

        [JsonPropertyName("announce_subject")]
        public string AnnounceSubject { get; set; } = null!;

        [JsonPropertyName("announce_image")]
        public string? AnnounceImage { get; set; }

        [JsonPropertyName("attachment")]
        public string? Attachment { get; set; }

        [JsonPropertyName("announce_content")]
        public string? AnnounceContent { get; set; }

        [JsonPropertyName("status")]
        public int? Status { get; set; }

        [JsonPropertyName("active_status")]
        public int? ActiveStatus { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
