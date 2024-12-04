using ThePatho.Features.Applicant.ApplicantRecruitStep.DTO;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Service
{
    public interface IApplicantRecruitStepService
    {
        Task<List<ApplicantRecruitStepDto>> GetAllApplicantRecruitStepAsync();
        Task<ApplicantRecruitStepDto?> GetApplicantRecruitStepByCodeAsync( string code);
        Task<ApplicantRecruitStepDto> AddApplicantRecruitStepAsync(ApplicantRecruitStepDto step);
        Task<ApplicantRecruitStepDto?> UpdateApplicantRecruitStepAsync(ApplicantRecruitStepDto step);
        Task<bool> DeleteApplicantRecruitStepAsync(string code);
    }
}
