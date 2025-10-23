using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Room.DTO;

namespace ThePatho.Features.Global.Room.Commands
{
    public class GetSingleRoomCommand : IRequest<ApiResponse<RoomDto>>
    {
        [JsonPropertyName("filter_RoomCode")]
        public string FilterRoomCode { get; set; }
    }
}
