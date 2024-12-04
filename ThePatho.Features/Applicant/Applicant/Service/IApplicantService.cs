using ThePatho.Features.Applicant.Applicant.DTO;

namespace ThePatho.Features.Applicant.Applicant.Service
{
    public interface IApplicantService
    {
        Task<List<ApplicantDto>> GetAllApplicantsAsync();
        Task<ApplicantDto?> GetApplicantByIdAsync(int id);
        Task<ApplicantDto> AddApplicantAsync(ApplicantDto applicant);
        Task<ApplicantDto?> UpdateApplicantAsync(ApplicantDto applicant);
        Task<bool> DeleteApplicantAsync(int id);
    }
}
