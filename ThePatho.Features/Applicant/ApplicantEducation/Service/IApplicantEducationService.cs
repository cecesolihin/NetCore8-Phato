using ThePatho.Features.Applicant.ApplicantEducation.Commands;
using ThePatho.Features.Applicant.ApplicantEducation.DTO;

namespace ThePatho.Features.Applicant.ApplicantEducation.Service
{
    public interface IApplicantEducationService 
    {
        Task<List<ApplicantEducationDto>> GetApplicantEducation(GetApplicantEducationCommand request);
        Task<ApplicantEducationDto> GetApplicantEducationByCriteria(GetApplicantEducationByCriteriaCommand request);
        Task<bool> SubmitApplicantEducation(SubmitApplicantEducationCommand request);
        Task<bool> DeleteApplicantEducation(DeleteApplicantEducationCommand request);
    }
}
