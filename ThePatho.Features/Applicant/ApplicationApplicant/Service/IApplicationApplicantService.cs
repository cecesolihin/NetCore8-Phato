using ThePatho.Features.Applicant.ApplicationApplicant.DTO;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Service
{
    public interface IApplicationApplicantService
    {
        Task<List<ApplicationApplicantDto>> GetAllApplicationApplicantAsync();
        Task<ApplicationApplicantDto?> GetApplicationApplicantByCodeAsync(string code);
        Task<ApplicationApplicantDto> AddApplicationApplicantAsync(ApplicationApplicantDto applicant);
        Task<ApplicationApplicantDto?> UpdateApplicationApplicantAsync(ApplicationApplicantDto applicant);
        Task<bool> DeleteApplicationApplicantAsync(string code);
    }
}
