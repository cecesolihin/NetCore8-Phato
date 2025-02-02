using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterData.AdsMedia.Commands;
using ThePatho.Features.MasterData.AdsMedia.DTO;

namespace ThePatho.Features.MasterData.AdsMedia.Service
{
    public interface IAdsMediaService
    {
        Task<NewApiResponse<AdsMediaItemDto>> GetAdsMedia(GetAdsMediaCommand request);
        Task<NewApiResponse<AdsMediaDto>> GetAdsMediaByCriteria(GetAdsMediaByCriteriaCommand request);
        Task<NewApiResponse<AdsMediaItemDto>> GetAdsMediaDdl(GetAdsMediaDdlCommand request);
        Task<ApiResponse> SubmitAdsMedia(SubmitAdsMediaCommand request);
        Task<ApiResponse> DeleteAdsMedia(DeleteAdsMediaCommand request);
    }
}
