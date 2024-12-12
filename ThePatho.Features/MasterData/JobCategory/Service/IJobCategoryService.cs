using ThePatho.Features.MasterData.AdsCategory.Commands;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.DTO;

namespace ThePatho.Features.MasterData.JobCategory.Service
{
    public interface IJobCategoryService
    {
        Task<List<JobCategoryDto>> GetJobCategory(GetJobCategoryCommand request);
        Task<JobCategoryDto> GetJobCategoryByCode(GetJobCategoryByCodeCommand request);
        Task<List<JobCategoryDto>> GetJobCategoryDdl(GetJobCategoryDdlCommand request);
    }
}
