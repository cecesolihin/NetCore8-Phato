using ThePatho.Features.Applicant.ApplicantSkill.DTO;

namespace ThePatho.Features.Applicant.ApplicantSkill.Service
{
    public interface IApplicantSkillService
    {
        Task<List<ApplicantSkillDto>> GetAllApplicantSkillAsync();
        Task<ApplicantSkillDto?> GetApplicantSkillByCodeAsync(string code);
        Task<ApplicantSkillDto> AddApplicantSkillAsync(ApplicantSkillDto skill);
        Task<ApplicantSkillDto?> UpdateApplicantSkillAsync(ApplicantSkillDto skill);
        Task<bool> DeleteApplicantSkillAsync(string code);
    }
}
