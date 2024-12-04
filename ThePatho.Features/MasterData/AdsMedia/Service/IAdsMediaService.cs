using ThePatho.Features.MasterData.AdsMedia.DTO;

namespace ThePatho.Features.MasterData.AdsMedia.Service
{
    public interface IAdsMediaService
    {
        Task<List<AdsMediaDto>> GetAllAdsMediaAsync();
        Task<AdsMediaDto?> GetAdsMediaByCodeAsync(string adsMediaCode);
        Task<AdsMediaDto> AddAdsMediaAsync(AdsMediaDto adsMedia);
        Task<AdsMediaDto?> UpdateAdsMediaAsync(AdsMediaDto adsMedia);
        Task<bool> DeleteAdsMediaAsync(string adsMediaCode);
    }
}
