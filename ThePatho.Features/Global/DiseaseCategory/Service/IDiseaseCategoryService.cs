using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.DiseaseCategory.Commands;
using ThePatho.Features.Global.DiseaseCategory.DTO;

namespace ThePatho.Features.Global.DiseaseCategory.Service
{
    public interface IDiseaseCategoryService
    {
        Task<ApiResponse<DiseaseCategoryItemDto>> GetDiseaseCategory(GetDiseaseCategoryCommand request);
        Task<ApiResponse<DiseaseCategoryItemDto>> GetDiseaseCategoryByCriteria(GetDiseaseCategoryByCriteriaCommand request);
        Task<ApiResponse> SubmitDiseaseCategory(SubmitDiseaseCategoryCommand request);
        Task<ApiResponse> DeleteDiseaseCategory(DeleteDiseaseCategoryCommand request);
        Task<ApiResponse<DiseaseCategoryDto>> GetSingleDiseaseCategory(GetSingleDiseaseCategoryCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportDiseaseCategoryCommand request);
    }
}

