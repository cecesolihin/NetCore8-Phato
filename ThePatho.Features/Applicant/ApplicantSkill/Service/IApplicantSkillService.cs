using ThePatho.Features.Applicant.ApplicantSkill.Commands;
using ThePatho.Features.Applicant.ApplicantSkill.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantSkill.Service
{
    public interface IApplicantSkillService
    {
        Task<NewApiResponse<ApplicantSkillItemDto>> GetApplicantSkill(GetApplicantSkillCommand request);
        Task<NewApiResponse<ApplicantSkillDto>> GetApplicantSkillByCriteria(GetApplicantSkillByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantSkill(SubmitApplicantSkillCommand request);
        Task<ApiResponse> DeleteApplicantSkill(DeleteApplicantSkillCommand request);
    }
}
