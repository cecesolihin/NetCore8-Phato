using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterData.JobCategory.Commands;
using ThePatho.Features.MasterData.JobCategory.DTO;

namespace ThePatho.Features.MasterData.JobCategory.Service
{
    public interface IJobCategoryService
    {
        Task<NewApiResponse<JobCategoryItemDto>> GetJobCategory(GetJobCategoryCommand request);
        Task<NewApiResponse<JobCategoryDto>> GetJobCategoryByCriteria(GetJobCategoryByCriteriaCommand request);
        Task<NewApiResponse<JobCategoryItemDto>> GetJobCategoryDdl(GetJobCategoryDdlCommand request);
        Task<ApiResponse> SubmitJobCategory(SubmitJobCategoryCommand request);
        Task<ApiResponse> DeleteJobCategory(DeleteJobCategoryCommand request);
    }
}
