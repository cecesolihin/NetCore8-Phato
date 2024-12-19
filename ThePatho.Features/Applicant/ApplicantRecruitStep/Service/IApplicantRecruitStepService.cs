using ThePatho.Features.Applicant.ApplicantRecruitStep.Commands;
using ThePatho.Features.Applicant.ApplicantRecruitStep.DTO;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Service
{
    public interface IApplicantRecruitStepService
    {
        Task<List<ApplicantRecruitStepDto>> GetApplicantRecruitStep(GetApplicantRecruitStepCommand request);
        Task<ApplicantRecruitStepDto> GetApplicantRecruitStepByCriteria(GetApplicantRecruitStepByCriteriaCommand request);
    }
}
