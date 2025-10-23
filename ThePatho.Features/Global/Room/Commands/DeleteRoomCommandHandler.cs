using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Room.Service;

namespace ThePatho.Features.Global.Room.Commands
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, ApiResponse>
    {
        private readonly IRoomService roomService;

        public DeleteRoomCommandHandler(IRoomService _roomService)
        {
            roomService = _roomService;
        }

        public async Task<ApiResponse> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            return await roomService.DeleteRoom(request);
        }
    }
}
