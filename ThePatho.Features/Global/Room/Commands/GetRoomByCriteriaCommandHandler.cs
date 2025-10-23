using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Room.Service;
using ThePatho.Features.Global.Room.DTO;

namespace ThePatho.Features.Global.Room.Commands
{
    public class GetRoomByCriteriaCommandHandler : IRequestHandler<GetRoomByCriteriaCommand, ApiResponse<RoomItemDto>>
    {
        private readonly IRoomService roomService;

        public GetRoomByCriteriaCommandHandler(IRoomService _roomService)
        {
            roomService = _roomService;
        }

        public async Task<ApiResponse<RoomItemDto>> Handle(GetRoomByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await roomService.GetRoomByCriteria(request);
        }
    }
}
