using ThePatho.Features.Applicant.ApplicantSkill.Commands;
using ThePatho.Features.Applicant.ApplicantSkill.DTO;

namespace ThePatho.Features.Applicant.ApplicantSkill.Service
{
    public interface IApplicantSkillService
    {
        Task<List<ApplicantSkillDto>> GetApplicantSkill(GetApplicantSkillCommand request);
        Task<ApplicantSkillDto> GetApplicantSkillByCriteria(GetApplicantSkillByCriteriaCommand request);
        Task<bool> SubmitApplicantSkill(SubmitApplicantSkillCommand request);
        Task<bool> DeleteApplicantSkill(DeleteApplicantSkillCommand request);
    }
}
