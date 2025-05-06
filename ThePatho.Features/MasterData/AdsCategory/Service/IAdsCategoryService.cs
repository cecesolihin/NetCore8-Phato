using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsCategory.Commands;
using ThePatho.Features.MasterData.AdsCategory.DTO;

namespace ThePatho.Features.MasterData.AdsCategory.Service
{
    public interface IAdsCategoryService
    {
        Task<ApiResponse<AdsCategoryItemDto>> GetAllAdsCategories(GetAdsCategoryCommand request);
        Task<ApiResponse<AdsCategoryDto>> GetAdsCategoryByCriteria(GetAdsCategoryByCriteriaCommand request);
        Task<ApiResponse<AdsCategoryItemDto>> GetAdsCategoriesDdl(GetAdsCategoryDdlCommand request);
        Task<ApiResponse> SubmitAdsCategory(SubmitAdsCategoryCommand request);
        Task<ApiResponse> DeleteAdsCategory(DeleteAdsCategoryCommand request);
    }
}
