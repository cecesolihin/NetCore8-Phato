using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Room.Commands;
using ThePatho.Features.Global.Room.DTO;

namespace ThePatho.Features.Global.Room.Service
{
    public interface IRoomService
    {
        Task<ApiResponse<RoomItemDto>> GetRoom(GetRoomCommand request);
        Task<ApiResponse<RoomDto>> GetSingleRoom(GetSingleRoomCommand request);
        Task<ApiResponse<RoomItemDto>> GetRoomByCriteria(GetRoomByCriteriaCommand request);
        Task<ApiResponse> SubmitRoom(SubmitRoomCommand request);
        Task<ApiResponse> DeleteRoom(DeleteRoomCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportRoomCommand request);
    }
}

