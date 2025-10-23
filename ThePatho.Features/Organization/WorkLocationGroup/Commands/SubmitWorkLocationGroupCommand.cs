using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.WorkLocationGroup.Commands
{
    public class SubmitWorkLocationGroupCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("group_detail_id")]
        public int GroupDetailId { get; set; }

        [JsonPropertyName("group_id")]
        public int GroupId { get; set; }

        [JsonPropertyName("work_location_code")]
        public string? WorkLocationCode { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
