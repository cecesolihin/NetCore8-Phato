using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.JobCategory.Commands;
using ThePatho.Features.MasterData.JobCategory.DTO;

namespace ThePatho.Features.MasterData.JobCategory.Service
{
    public interface IJobCategoryService
    {
        Task<ApiResponse<JobCategoryItemDto>> GetJobCategory(GetJobCategoryCommand request);
        Task<ApiResponse<JobCategoryDto>> GetJobCategoryByCriteria(GetJobCategoryByCriteriaCommand request);
        Task<ApiResponse<JobCategoryItemDto>> GetJobCategoryDdl(GetJobCategoryDdlCommand request);
        Task<ApiResponse> SubmitJobCategory(SubmitJobCategoryCommand request);
        Task<ApiResponse> DeleteJobCategory(DeleteJobCategoryCommand request);
    }
}
