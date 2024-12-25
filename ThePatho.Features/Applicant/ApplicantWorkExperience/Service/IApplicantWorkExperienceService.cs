using ThePatho.Features.Applicant.ApplicantWorkExperience.Commands;
using ThePatho.Features.Applicant.ApplicantWorkExperience.DTO;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Service
{
    public interface IApplicantWorkExperienceService
    {
        Task<List<ApplicantWorkExperienceDto>> GetApplicantWorkExperience(GetApplicantWorkExperienceCommand request);
        Task<ApplicantWorkExperienceDto> GetApplicantWorkExperienceByCriteria(GetApplicantWorkExperienceByCriteriaCommand request); 
    }
}
