using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Room.Service;
using ThePatho.Features.Global.Room.DTO;

namespace ThePatho.Features.Global.Room.Commands
{
    public class GetRoomCommandHandler : IRequestHandler<GetRoomCommand, ApiResponse<RoomItemDto>>
    {
        private readonly IRoomService roomService;

        public GetRoomCommandHandler(IRoomService _roomService)
        {
            roomService = _roomService;
        }

        public async Task<ApiResponse<RoomItemDto>> Handle(GetRoomCommand request, CancellationToken cancellationToken)
        {
            return await roomService.GetRoom(request);
        }
    }
}
