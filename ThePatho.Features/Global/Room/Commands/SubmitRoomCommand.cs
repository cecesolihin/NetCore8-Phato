using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Room.Commands
{
    public class SubmitRoomCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("room_code")]
        public string RoomCode { get; set; } = null!;

        [JsonPropertyName("room_name")]
        public string RoomName { get; set; } = null!;

        [JsonPropertyName("building_code")]
        public string BuildingCode { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
