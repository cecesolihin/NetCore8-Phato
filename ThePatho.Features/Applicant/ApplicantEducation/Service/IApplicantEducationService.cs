using ThePatho.Features.Applicant.ApplicantEducation.Commands;
using ThePatho.Features.Applicant.ApplicantEducation.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantEducation.Service
{
    public interface IApplicantEducationService 
    {
        Task<ApiResponse<ApplicantEducationItemDto>> GetApplicantEducation(GetApplicantEducationCommand request);
        Task<ApiResponse<ApplicantEducationDto>> GetApplicantEducationByCriteria(GetApplicantEducationByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantEducation(SubmitApplicantEducationCommand request);
        Task<ApiResponse> DeleteApplicantEducation(DeleteApplicantEducationCommand request);
    }
}
