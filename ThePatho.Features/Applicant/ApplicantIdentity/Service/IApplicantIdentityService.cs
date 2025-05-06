using ThePatho.Features.Applicant.ApplicantIdentity.Commands;
using ThePatho.Features.Applicant.ApplicantIdentity.Commands;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Service
{
    public interface IApplicantIdentityService
    {
        Task<ApiResponse<ApplicantIdentityItemDto>> GetApplicantIdentity(GetApplicantIdentityCommand request);
        Task<ApiResponse<ApplicantIdentityDto>> GetApplicantIdentityByCriteria(GetApplicantIdentityByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantIdentity(SubmitApplicantIdentityCommand request);
        Task<ApiResponse> DeleteApplicantIdentity(DeleteApplicantIdentityCommand request);
    }
}