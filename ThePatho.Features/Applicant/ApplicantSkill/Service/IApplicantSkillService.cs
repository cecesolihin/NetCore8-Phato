using ThePatho.Features.Applicant.ApplicantSkill.Commands;
using ThePatho.Features.Applicant.ApplicantSkill.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantSkill.Service
{
    public interface IApplicantSkillService
    {
        Task<ApiResponse<ApplicantSkillItemDto>> GetApplicantSkill(GetApplicantSkillCommand request);
        Task<ApiResponse<ApplicantSkillDto>> GetApplicantSkillByCriteria(GetApplicantSkillByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantSkill(SubmitApplicantSkillCommand request);
        Task<ApiResponse> DeleteApplicantSkill(DeleteApplicantSkillCommand request);
    }
}
