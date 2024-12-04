using ThePatho.Features.MasterData.JobCategory.DTO;

namespace ThePatho.Features.MasterData.JobCategory.Service
{
    public interface IJobCategoryService
    {
        Task<List<JobCategoryDto>> GetAllJobCategoriesAsync();
        Task<JobCategoryDto?> GetJobCategoryByCodeAsync(string jobCategoryCode);
        Task<JobCategoryDto> AddJobCategoryAsync(JobCategoryDto jobCategory);
        Task<JobCategoryDto?> UpdateJobCategoryAsync(JobCategoryDto jobCategory);
        Task<bool> DeleteJobCategoryAsync(string jobCategoryCode);
    }
}
