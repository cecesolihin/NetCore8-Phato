using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterData.AdsCategory.Commands;
using ThePatho.Features.MasterData.AdsCategory.DTO;

namespace ThePatho.Features.MasterData.AdsCategory.Service
{
    public interface IAdsCategoryService
    {
        Task<NewApiResponse<AdsCategoryItemDto>> GetAllAdsCategories(GetAdsCategoryCommand request);
        Task<NewApiResponse<AdsCategoryDto>> GetAdsCategoryByCriteria(GetAdsCategoryByCriteriaCommand request);
        Task<NewApiResponse<AdsCategoryItemDto>> GetAdsCategoriesDdl(GetAdsCategoryDdlCommand request);
        Task<ApiResponse> SubmitAdsCategory(SubmitAdsCategoryCommand request);
        Task<ApiResponse> DeleteAdsCategory(DeleteAdsCategoryCommand request);
    }
}
