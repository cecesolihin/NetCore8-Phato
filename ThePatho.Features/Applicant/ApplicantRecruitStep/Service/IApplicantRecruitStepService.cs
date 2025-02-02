using ThePatho.Features.Applicant.ApplicantRecruitStep.Commands;
using ThePatho.Features.Applicant.ApplicantRecruitStep.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Service
{
    public interface IApplicantRecruitStepService
    {
        Task<NewApiResponse<ApplicantRecruitStepItemDto>> GetApplicantRecruitStep(GetApplicantRecruitStepCommand request);
        Task<NewApiResponse<ApplicantRecruitStepDto>> GetApplicantRecruitStepByCriteria(GetApplicantRecruitStepByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantRecruitStep(SubmitApplicantRecruitStepCommand request);
        Task<ApiResponse> DeleteApplicantRecruitStep(DeleteApplicantRecruitStepCommand request);
    }
}
