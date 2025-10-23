using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Room.DTO;

namespace ThePatho.Features.Global.Room.Commands
{
    public class GetRoomByCriteriaCommand : IRequest<ApiResponse<RoomItemDto>>
    {
        [JsonPropertyName("filter_RoomName")]
        public string? FilterRoomName { get; set; }

        [JsonPropertyName("filter_RoomCode")]
        public string? FilterRoomCode { get; set; }

        [JsonPropertyName("filter_BuildingCode")]
        public string? FilterBuildingCode { get; set; }

    }
}
