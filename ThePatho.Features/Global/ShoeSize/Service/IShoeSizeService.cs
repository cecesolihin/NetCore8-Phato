using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ShoeSize.Commands;
using ThePatho.Features.Global.ShoeSize.DTO;

namespace ThePatho.Features.Global.ShoeSize.Service
{
    public interface IShoeSizeService
    {
        Task<ApiResponse<ShoeSizeItemDto>> GetShoeSize(GetShoeSizeCommand request);
        Task<ApiResponse<ShoeSizeDto>> GetSingleShoeSize(GetSingleShoeSizeCommand request);
        Task<ApiResponse<ShoeSizeItemDto>> GetShoeSizeByCriteria(GetShoeSizeByCriteriaCommand request);
        Task<ApiResponse> SubmitShoeSize(SubmitShoeSizeCommand request);
        Task<ApiResponse> DeleteShoeSize(DeleteShoeSizeCommand request);
    }
}
