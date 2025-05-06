using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsMedia.Commands;
using ThePatho.Features.MasterData.AdsMedia.DTO;

namespace ThePatho.Features.MasterData.AdsMedia.Service
{
    public interface IAdsMediaService
    {
        Task<ApiResponse<AdsMediaItemDto>> GetAdsMedia(GetAdsMediaCommand request);
        Task<ApiResponse<AdsMediaDto>> GetAdsMediaByCriteria(GetAdsMediaByCriteriaCommand request);
        Task<ApiResponse<AdsMediaItemDto>> GetAdsMediaDdl(GetAdsMediaDdlCommand request);
        Task<ApiResponse> SubmitAdsMedia(SubmitAdsMediaCommand request);
        Task<ApiResponse> DeleteAdsMedia(DeleteAdsMediaCommand request);
    }
}
