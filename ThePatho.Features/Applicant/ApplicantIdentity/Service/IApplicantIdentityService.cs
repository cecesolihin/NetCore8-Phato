using ThePatho.Features.Applicant.ApplicantIdentity.Commands;
using ThePatho.Features.Applicant.ApplicantIdentity.Commands;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Service
{
    public interface IApplicantIdentityService
    {
        Task<NewApiResponse<ApplicantIdentityItemDto>> GetApplicantIdentity(GetApplicantIdentityCommand request);
        Task<NewApiResponse<ApplicantIdentityDto>> GetApplicantIdentityByCriteria(GetApplicantIdentityByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantIdentity(SubmitApplicantIdentityCommand request);
        Task<ApiResponse> DeleteApplicantIdentity(DeleteApplicantIdentityCommand request);
    }
}