using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RadiusUnit.Commands;
using ThePatho.Features.Global.RadiusUnit.DTO;

namespace ThePatho.Features.Global.RadiusUnit.Service
{
    public interface IRadiusUnitService
    {
        Task<ApiResponse<RadiusUnitItemDto>> GetRadiusUnit(GetRadiusUnitCommand request);
        Task<ApiResponse<RadiusUnitDto>> GetSingleRadiusUnit(GetSingleRadiusUnitCommand request);
        Task<ApiResponse<RadiusUnitItemDto>> GetRadiusUnitByCriteria(GetRadiusUnitByCriteriaCommand request);
        Task<ApiResponse> SubmitRadiusUnit(SubmitRadiusUnitCommand request);
        Task<ApiResponse> DeleteRadiusUnit(DeleteRadiusUnitCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportRadiusUnitCommand request);
    }
}

