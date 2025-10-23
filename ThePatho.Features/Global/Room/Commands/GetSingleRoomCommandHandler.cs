using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Room.Service;
using ThePatho.Features.Global.Room.DTO;

namespace ThePatho.Features.Global.Room.Commands
{
    public class GetSingleRoomCommandHandler : IRequestHandler<GetSingleRoomCommand, ApiResponse<RoomDto>>
    {
        private readonly IRoomService Service;

        public GetSingleRoomCommandHandler(IRoomService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<RoomDto>> Handle(GetSingleRoomCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleRoom(request);
        }
    }
}
