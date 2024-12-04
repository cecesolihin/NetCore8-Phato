using ThePatho.Features.Applicant.ApplicantWorkExperience.DTO;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Service
{
    public interface IApplicantWorkExperienceService
    {
        Task<List<ApplicantWorkExperienceDto>> GetAllApplicantWorkExperienceAsync();
        Task<ApplicantWorkExperienceDto?> GetApplicantWorkExperienceByCodeAsync(string code);
        Task<ApplicantWorkExperienceDto> AddApplicantWorkExperienceAsync(ApplicantWorkExperienceDto experience);
        Task<ApplicantWorkExperienceDto?> UpdateApplicantWorkExperienceAsync(ApplicantWorkExperienceDto experience);
        Task<bool> DeleteApplicantWorkExperienceAsync(string code);
    }
}
