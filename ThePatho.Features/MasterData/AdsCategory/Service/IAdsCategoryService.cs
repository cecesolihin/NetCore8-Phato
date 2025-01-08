using ThePatho.Features.MasterData.AdsCategory.Commands;
using ThePatho.Features.MasterData.AdsCategory.DTO;

namespace ThePatho.Features.MasterData.AdsCategory.Service
{
    public interface IAdsCategoryService
    {
        Task<List<AdsCategoryDto>> GetAllAdsCategories(GetAdsCategoryCommand request);
        Task<AdsCategoryDto> GetAdsCategoryByCriteria(GetAdsCategoryByCriteriaCommand request);
        Task<List<AdsCategoryDto>> GetAdsCategoriesDdl(GetAdsCategoryDdlCommand request);
        Task SubmitAdsCategory(SubmitAdsCategoryCommand request);
        Task DeleteAdsCategory(DeleteAdsCategoryCommand request);
    }
}
