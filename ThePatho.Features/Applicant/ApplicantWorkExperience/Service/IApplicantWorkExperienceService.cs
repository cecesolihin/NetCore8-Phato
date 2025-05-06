using ThePatho.Features.Applicant.ApplicantWorkExperience.Commands;
using ThePatho.Features.Applicant.ApplicantWorkExperience.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Service
{
    public interface IApplicantWorkExperienceService
    {
        Task<ApiResponse<ApplicantWorkExperienceItemDto>> GetApplicantWorkExperience(GetApplicantWorkExperienceCommand request);
        Task<ApiResponse<ApplicantWorkExperienceDto>> GetApplicantWorkExperienceByCriteria(GetApplicantWorkExperienceByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantWorkExperience(SubmitApplicantWorkExperienceCommand request);
        Task<ApiResponse> DeleteApplicantWorkExperience(DeleteApplicantWorkExperienceCommand request);
    }
}
