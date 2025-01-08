using ThePatho.Features.MasterData.JobCategory.Commands;
using ThePatho.Features.MasterData.JobCategory.DTO;

namespace ThePatho.Features.MasterData.JobCategory.Service
{
    public interface IJobCategoryService
    {
        Task<List<JobCategoryDto>> GetJobCategory(GetJobCategoryCommand request);
        Task<JobCategoryDto> GetJobCategoryByCriteria(GetJobCategoryByCriteriaCommand request);
        Task<List<JobCategoryDto>> GetJobCategoryDdl(GetJobCategoryDdlCommand request);
        Task SubmitJobCategory(SubmitJobCategoryCommand request);
        Task DeleteJobCategory(DeleteJobCategoryCommand request);
    }
}
