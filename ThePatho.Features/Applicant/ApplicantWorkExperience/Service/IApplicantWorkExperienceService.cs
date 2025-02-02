using ThePatho.Features.Applicant.ApplicantWorkExperience.Commands;
using ThePatho.Features.Applicant.ApplicantWorkExperience.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Service
{
    public interface IApplicantWorkExperienceService
    {
        Task<NewApiResponse<ApplicantWorkExperienceItemDto>> GetApplicantWorkExperience(GetApplicantWorkExperienceCommand request);
        Task<NewApiResponse<ApplicantWorkExperienceDto>> GetApplicantWorkExperienceByCriteria(GetApplicantWorkExperienceByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantWorkExperience(SubmitApplicantWorkExperienceCommand request);
        Task<ApiResponse> DeleteApplicantWorkExperience(DeleteApplicantWorkExperienceCommand request);
    }
}
