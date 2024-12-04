using ThePatho.Features.MasterData.AdsCategory.DTO;

namespace ThePatho.Features.MasterData.AdsCategory.Service
{
    public interface IAdsCategoryService
    {
        Task<List<AdsCategoryDto>> GetAllAdsCategoriesAsync();
        Task<AdsCategoryDto?> GetAdsCategoryByCodeAsync(string adsCategoryCode);
        Task<AdsCategoryDto> AddAdsCategoryAsync(AdsCategoryDto adsCategory);
        Task<AdsCategoryDto?> UpdateAdsCategoryAsync(AdsCategoryDto adsCategory);
        Task<bool> DeleteAdsCategoryAsync(string adsCategoryCode);
    }
}
