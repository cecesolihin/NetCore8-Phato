using ThePatho.Features.Applicant.ApplicantEducation.DTO;

namespace ThePatho.Features.Applicant.ApplicantEducation.Service
{
    public interface IApplicantEducationService
    {
        Task<List<ApplicantEducationDto>> GetAllApplicantEducationsAsync();
        Task<ApplicantEducationDto?> GetApplicantEducationByCodeAsync(string applicantNo);
        Task<ApplicantEducationDto> AddApplicantEducationAsync(ApplicantEducationDto education);
        Task<ApplicantEducationDto?> UpdateApplicantEducationAsync(ApplicantEducationDto education);
        Task<bool> DeleteApplicantEducationAsync(string code);
    }
}
