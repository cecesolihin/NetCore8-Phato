using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterCategory.Commands;
using ThePatho.Features.Global.LetterCategory.DTO;

namespace ThePatho.Features.Global.LetterCategory.Service
{
    public interface ILetterCategoryService
    {
        Task<ApiResponse<LetterCategoryItemDto>> GetLetterCategory(GetLetterCategoryCommand request);
        Task<ApiResponse<LetterCategoryDto>> GetSingleLetterCategory(GetSingleLetterCategoryCommand request);
        Task<ApiResponse<LetterCategoryItemDto>> GetLetterCategoryByCriteria(GetLetterCategoryByCriteriaCommand request);
        Task<ApiResponse> SubmitLetterCategory(SubmitLetterCategoryCommand request);
        Task<ApiResponse> DeleteLetterCategory(DeleteLetterCategoryCommand request);
    }
}
