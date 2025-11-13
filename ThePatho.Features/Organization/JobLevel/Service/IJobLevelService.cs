
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevel.Commands;
using ThePatho.Features.Organization.JobLevel.DTO;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.JobLevel.Service
{
    public interface IJobLevelService
    {
        Task<ApiResponse<JobLevelItemDto>> GetJobLevel(GetJobLevelCommand request);
        Task<ApiResponse<JobLevelDto>> GetSingleJobLevel(GetSingleJobLevelCommand request);
        Task<ApiResponse<JobLevelItemDto>> GetJobLevelByCriteria(GetJobLevelByCriteriaCommand request);
        Task<ApiResponse> SubmitJobLevel(SubmitJobLevelCommand request);
        Task<ApiResponse> DeleteJobLevel(DeleteJobLevelCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportJobLevelAsync(string type);
    }
}
