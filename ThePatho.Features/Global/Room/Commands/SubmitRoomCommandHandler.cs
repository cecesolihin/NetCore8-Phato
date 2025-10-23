using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Room.Service;

namespace ThePatho.Features.Global.Room.Commands
{
    public class SubmitRoomCommandHandler : IRequestHandler<SubmitRoomCommand, ApiResponse>
    {
        private readonly IRoomService roomService;

        public SubmitRoomCommandHandler(IRoomService _roomService)
        {
            roomService = _roomService;
        }

        public async Task<ApiResponse> Handle(SubmitRoomCommand request, CancellationToken cancellationToken)
        {
            return await roomService.SubmitRoom(request);
        }
    }
}
