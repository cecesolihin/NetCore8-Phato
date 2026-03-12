using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryCondition.Commands;
using ThePatho.Features.Global.InventoryCondition.DTO;

namespace ThePatho.Features.Global.InventoryCondition.Service
{
    public interface IInventoryConditionService
    {
        Task<ApiResponse<InventoryConditionItemDto>> GetInventoryCondition(GetInventoryConditionCommand request);
        Task<ApiResponse<InventoryConditionDto>> GetSingleInventoryCondition(GetSingleInventoryConditionCommand request);
        Task<ApiResponse<InventoryConditionItemDto>> GetInventoryConditionByCriteria(GetInventoryConditionByCriteriaCommand request);
        Task<ApiResponse> SubmitInventoryCondition(SubmitInventoryConditionCommand request);
        Task<ApiResponse> DeleteInventoryCondition(DeleteInventoryConditionCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportInventoryConditionCommand request);
    }
}

