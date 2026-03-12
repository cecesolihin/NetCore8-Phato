using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroupDetail.Commands;
using ThePatho.Features.Global.InventoryGroupDetail.DTO;

namespace ThePatho.Features.Global.InventoryGroupDetail.Service
{
    public interface IInventoryGroupDetailService
    {
        Task<ApiResponse<InventoryGroupDetailItemDto>> GetInventoryGroupDetail(GetInventoryGroupDetailCommand request);
        Task<ApiResponse<InventoryGroupDetailItemDto>> GetInventoryGroupDetailByCriteria(GetInventoryGroupDetailByCriteriaCommand request);
        Task<ApiResponse> SubmitInventoryGroupDetail(SubmitInventoryGroupDetailCommand request);
        Task<ApiResponse> DeleteInventoryGroupDetail(DeleteInventoryGroupDetailCommand request);

        Task<ApiResponse<InventoryGroupDetailDto>> GetSingleInventoryGroupDetail(GetSingleInventoryGroupDetailCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportInventoryGroupDetailCommand request);
    }
}

