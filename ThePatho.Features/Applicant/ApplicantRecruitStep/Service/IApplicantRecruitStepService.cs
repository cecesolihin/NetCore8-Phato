using ThePatho.Features.Applicant.ApplicantRecruitStep.Commands;
using ThePatho.Features.Applicant.ApplicantRecruitStep.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Service
{
    public interface IApplicantRecruitStepService
    {
        Task<ApiResponse<ApplicantRecruitStepItemDto>> GetApplicantRecruitStep(GetApplicantRecruitStepCommand request);
        Task<ApiResponse<ApplicantRecruitStepDto>> GetApplicantRecruitStepByCriteria(GetApplicantRecruitStepByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantRecruitStep(SubmitApplicantRecruitStepCommand request);
        Task<ApiResponse> DeleteApplicantRecruitStep(DeleteApplicantRecruitStepCommand request);
    }
}
