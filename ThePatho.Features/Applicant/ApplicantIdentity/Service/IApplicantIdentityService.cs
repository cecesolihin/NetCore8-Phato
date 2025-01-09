using ThePatho.Features.Applicant.ApplicantIdentity.Commands;
using ThePatho.Features.Applicant.ApplicantIdentity.Commands;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Service
{
    public interface IApplicantIdentityService
    {
        Task<List<ApplicantIdentityDto>> GetApplicantIdentity(GetApplicantIdentityCommand request);
        Task<ApplicantIdentityDto> GetApplicantIdentityByCriteria(GetApplicantIdentityByCriteriaCommand request);
        Task<bool> SubmitApplicantIdentity(SubmitApplicantIdentityCommand request);
        Task<bool> DeleteApplicantIdentity(DeleteApplicantIdentityCommand request);
    }
}