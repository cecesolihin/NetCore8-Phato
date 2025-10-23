using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroup.Commands;
using ThePatho.Features.Global.InventoryGroup.DTO;

namespace ThePatho.Features.Global.InventoryGroup.Service
{
    public interface IInventoryGroupService
    {
        Task<ApiResponse<InventoryGroupItemDto>> GetInventoryGroup(GetInventoryGroupCommand request);
        Task<ApiResponse<InventoryGroupItemDto>> GetInventoryGroupByCriteria(GetInventoryGroupByCriteriaCommand request);
        Task<ApiResponse> SubmitInventoryGroup(SubmitInventoryGroupCommand request);
        Task<ApiResponse> DeleteInventoryGroup(DeleteInventoryGroupCommand request);

        Task<ApiResponse<InventoryGroupDto>> GetSingleInventoryGroup(GetSingleInventoryGroupCommand request);
    }
}
