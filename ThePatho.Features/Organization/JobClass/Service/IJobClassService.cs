using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobClass.Commands;
using ThePatho.Features.Organization.JobClass.DTO;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.JobClass.Service
{
    public interface IJobClassService
    {
        Task<ApiResponse<JobClassItemDto>> GetJobClass(GetJobClassCommand request);
        Task<ApiResponse<JobClassDto>> GetSingleJobClass(GetSingleJobClassCommand request);
        Task<ApiResponse<JobClassItemDto>> GetJobClassByCriteria(GetJobClassByCriteriaCommand request);
        Task<ApiResponse> SubmitJobClass(SubmitJobClassCommand request);
        Task<ApiResponse> DeleteJobClass(DeleteJobClassCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportJobClassAsync(string type);
    }
}
