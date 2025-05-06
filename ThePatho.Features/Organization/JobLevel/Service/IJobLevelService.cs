
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevel.Commands;
using ThePatho.Features.Organization.JobLevel.DTO;

namespace ThePatho.Features.Organization.JobLevel.Service
{
    public interface IJobLevelService
    {
        Task<ApiResponse<JobLevelItemDto>> GetJobLevel(GetJobLevelCommand request);
        Task<ApiResponse<JobLevelDto>> GetJobLevelByCriteria(GetJobLevelByCriteriaCommand request);
        Task<ApiResponse> SubmitJobLevel(SubmitJobLevelCommand request);
        Task<ApiResponse> DeleteJobLevel(DeleteJobLevelCommand request);
    }
}
