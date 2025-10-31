using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CostCenter.Commands;
using ThePatho.Features.Organization.CostCenter.DTO;

namespace ThePatho.Features.Organization.CostCenter.Service
{
    public interface ICostCenterService
    {
        Task<ApiResponse<CostCenterItemDto>> GetCostCenter(GetCostCenterCommand request);
        Task<ApiResponse<CostCenterDto>> GetSingleCostCenter(GetSingleCostCenterCommand request);
        Task<ApiResponse<CostCenterItemDto>> GetCostCenterByCriteria(GetCostCenterByCriteriaCommand request);
        Task<ApiResponse> SubmitCostCenter(SubmitCostCenterCommand request);
        Task<ApiResponse> DeleteCostCenter(DeleteCostCenterCommand request);
    }
}
