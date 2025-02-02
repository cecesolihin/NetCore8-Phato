using ThePatho.Features.Applicant.ApplicationApplicant.Commands;
using ThePatho.Features.Applicant.ApplicationApplicant.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Service
{
    public interface IApplicationApplicantService
    {
        Task<NewApiResponse<ApplicationApplicantItemDto>> GetApplicationApplicant(GetApplicationApplicantCommand request);
        Task<NewApiResponse<ApplicationApplicantDto>> GetApplicationApplicantByCriteria(GetApplicationApplicantByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicationApplicant(SubmitApplicationApplicantCommand request);
        Task<ApiResponse> DeleteApplicationApplicant(DeleteApplicationApplicantCommand request);
    }
}
