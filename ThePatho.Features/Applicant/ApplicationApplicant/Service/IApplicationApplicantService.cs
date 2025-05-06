using ThePatho.Features.Applicant.ApplicationApplicant.Commands;
using ThePatho.Features.Applicant.ApplicationApplicant.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Service
{
    public interface IApplicationApplicantService
    {
        Task<ApiResponse<ApplicationApplicantItemDto>> GetApplicationApplicant(GetApplicationApplicantCommand request);
        Task<ApiResponse<ApplicationApplicantDto>> GetApplicationApplicantByCriteria(GetApplicationApplicantByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicationApplicant(SubmitApplicationApplicantCommand request);
        Task<ApiResponse> DeleteApplicationApplicant(DeleteApplicationApplicantCommand request);
    }
}
