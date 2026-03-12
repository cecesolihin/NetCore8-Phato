using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RomanianSize.Commands;
using ThePatho.Features.Global.RomanianSize.DTO;

namespace ThePatho.Features.Global.RomanianSize.Service
{
    public interface IRomanianSizeService
    {
        Task<ApiResponse<RomanianSizeItemDto>> GetRomanianSize(GetRomanianSizeCommand request);
        Task<ApiResponse<RomanianSizeDto>> GetSingleRomanianSize(GetSingleRomanianSizeCommand request);
        Task<ApiResponse<RomanianSizeItemDto>> GetRomanianSizeByCriteria(GetRomanianSizeByCriteriaCommand request);
        Task<ApiResponse> SubmitRomanianSize(SubmitRomanianSizeCommand request);
        Task<ApiResponse> DeleteRomanianSize(DeleteRomanianSizeCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportRomanianSizeCommand request);
    }
}

