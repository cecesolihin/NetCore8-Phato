using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.NumericalSize.Commands;
using ThePatho.Features.Global.NumericalSize.DTO;

namespace ThePatho.Features.Global.NumericalSize.Service
{
    public interface INumericalSizeService
    {
        Task<ApiResponse<NumericalSizeItemDto>> GetNumericalSize(GetNumericalSizeCommand request);
        Task<ApiResponse<NumericalSizeDto>> GetSingleNumericalSize(GetSingleNumericalSizeCommand request);
        Task<ApiResponse<NumericalSizeItemDto>> GetNumericalSizeByCriteria(GetNumericalSizeByCriteriaCommand request);
        Task<ApiResponse> SubmitNumericalSize(SubmitNumericalSizeCommand request);
        Task<ApiResponse> DeleteNumericalSize(DeleteNumericalSizeCommand request);
    }
}
