using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryType.Commands;
using ThePatho.Features.Global.InventoryType.DTO;

namespace ThePatho.Features.Global.InventoryType.Service
{
    public interface IInventoryTypeService
    {
        Task<ApiResponse<InventoryTypeItemDto>> GetInventoryType(GetInventoryTypeCommand request);
        Task<ApiResponse<InventoryTypeDto>> GetSingleInventoryType(GetSingleInventoryTypeCommand request);
        Task<ApiResponse<InventoryTypeItemDto>> GetInventoryTypeByCriteria(GetInventoryTypeByCriteriaCommand request);
        Task<ApiResponse> SubmitInventoryType(SubmitInventoryTypeCommand request);
        Task<ApiResponse> DeleteInventoryType(DeleteInventoryTypeCommand request);
    }
}
