using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroupOrg.Commands;
using ThePatho.Features.Global.InventoryGroupOrg.DTO;

namespace ThePatho.Features.Global.InventoryGroupOrg.Service
{
    public interface IInventoryGroupOrgService
    {
        Task<ApiResponse<InventoryGroupOrgItemDto>> GetInventoryGroupOrg(GetInventoryGroupOrgCommand request);
        Task<ApiResponse<InventoryGroupOrgItemDto>> GetInventoryGroupOrgByCriteria(GetInventoryGroupOrgByCriteriaCommand request);
        Task<ApiResponse> SubmitInventoryGroupOrg(SubmitInventoryGroupOrgCommand request);
        Task<ApiResponse> DeleteInventoryGroupOrg(DeleteInventoryGroupOrgCommand request);
        Task<ApiResponse<InventoryGroupOrgDto>> GetSingleInventoryGroupOrg(GetSingleInventoryGroupOrgCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportInventoryGroupOrgCommand request);
    }
}

