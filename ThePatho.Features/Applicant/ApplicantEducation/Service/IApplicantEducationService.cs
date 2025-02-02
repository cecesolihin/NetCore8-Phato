using ThePatho.Features.Applicant.ApplicantEducation.Commands;
using ThePatho.Features.Applicant.ApplicantEducation.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantEducation.Service
{
    public interface IApplicantEducationService 
    {
        Task<NewApiResponse<ApplicantEducationItemDto>> GetApplicantEducation(GetApplicantEducationCommand request);
        Task<NewApiResponse<ApplicantEducationDto>> GetApplicantEducationByCriteria(GetApplicantEducationByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantEducation(SubmitApplicantEducationCommand request);
        Task<ApiResponse> DeleteApplicantEducation(DeleteApplicantEducationCommand request);
    }
}
