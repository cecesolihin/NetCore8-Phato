
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Organization.JobLevel.Commands;
using ThePatho.Features.Organization.JobLevel.DTO;

namespace ThePatho.Features.Organization.JobLevel.Service
{
    public interface IJobLevelService
    {
        Task<NewApiResponse<JobLevelItemDto>> GetJobLevel(GetJobLevelCommand request);
        Task<NewApiResponse<JobLevelDto>> GetJobLevelByCriteria(GetJobLevelByCriteriaCommand request);
        Task<ApiResponse> SubmitJobLevel(SubmitJobLevelCommand request);
        Task<ApiResponse> DeleteJobLevel(DeleteJobLevelCommand request);
    }
}
