using ThePatho.Features.MasterData.AdsCategory.Commands;
using ThePatho.Features.MasterData.AdsCategory.DTO;

namespace ThePatho.Features.MasterData.AdsCategory.Service
{
    public interface IAdsCategoryService
    {
        Task<List<AdsCategoryDto>> GetAllAdsCategoriesAsync(GetAdsCategoryCommand request);
        Task<AdsCategoryDto> GetAdsCategoryByCode(GetAdsCategoryByCriteriaCommand request);
        Task<List<AdsCategoryDto>> GetAdsCategoriesDdl(GetAdsCategoryDdlCommand request);
    }
}
