using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Building.Commands;
using ThePatho.Features.Global.Building.DTO;

namespace ThePatho.Features.Global.Building.Service
{
    public interface IBuildingService
    {
        Task<ApiResponse<BuildingItemDto>> GetBuilding(GetBuildingCommand request);
        Task<ApiResponse<BuildingDto>> GetSingleBuilding(GetSingleBuildingCommand request);
        Task<ApiResponse<BuildingItemDto>> GetBuildingByCriteria(GetBuildingByCriteriaCommand request);
        Task<ApiResponse> SubmitBuilding(SubmitBuildingCommand request);
        Task<ApiResponse> DeleteBuilding(DeleteBuildingCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportBuildingCommand request);
    }
}

