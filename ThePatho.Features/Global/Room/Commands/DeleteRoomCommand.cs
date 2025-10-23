using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Room.Commands
{
    public class DeleteRoomCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("room_code")]
        public string RoomCode { get; set; } = null!;
    }
}
