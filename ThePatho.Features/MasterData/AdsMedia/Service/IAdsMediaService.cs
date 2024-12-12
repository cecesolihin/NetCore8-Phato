using ThePatho.Features.MasterData.AdsCategory.Commands;
using ThePatho.Features.MasterData.AdsMedia.DTO;

namespace ThePatho.Features.MasterData.AdsMedia.Service
{
    public interface IAdsMediaService
    {
        Task<List<AdsMediaDto>> GetAdsMedia(GetAdsMediaCommand request);
        Task<AdsMediaDto> GetAdsMediaByCode(GetAdsMediaByCodeCommand request);
        Task<List<AdsMediaDto>> GetAdsMediaDdl(GetAdsMediaDdlCommand request);
    
    }
}
