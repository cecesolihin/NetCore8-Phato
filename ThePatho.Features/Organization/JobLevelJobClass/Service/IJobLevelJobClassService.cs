using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevelJobClass.Commands;
using ThePatho.Features.Organization.JobLevelJobClass.DTO;

namespace ThePatho.Features.Organization.JobLevelJobClass.Service
{
    public interface IJobLevelJobClassService
    {
        Task<ApiResponse<JobLevelJobClassItemDto>> GetJobLevelJobClass(GetJobLevelJobClassCommand request);
        Task<ApiResponse<JobLevelJobClassDto>> GetSingleJobLevelJobClass(GetSingleJobLevelJobClassCommand request);
        Task<ApiResponse<JobLevelJobClassItemDto>> GetJobLevelJobClassByCriteria(GetJobLevelJobClassByCriteriaCommand request);
        Task<ApiResponse> SubmitJobLevelJobClass(SubmitJobLevelJobClassCommand request);
        Task<ApiResponse> DeleteJobLevelJobClass(DeleteJobLevelJobClassCommand request);
    }
}
