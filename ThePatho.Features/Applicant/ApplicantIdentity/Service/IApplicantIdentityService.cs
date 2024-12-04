using ThePatho.Features.Applicant.ApplicantIdentity.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Service
{
    public interface IApplicantIdentityService
    {
        Task<List<ApplicantIdentityDto>> GetAllApplicantIdentitiesAsync();
        Task<ApplicantIdentityDto?> GetApplicantIdentityByCodeAsync(string applicantNo);
        Task<ApplicantIdentityDto> AddApplicantIdentityAsync(ApplicantIdentityDto identity);
        Task<ApplicantIdentityDto?> UpdateApplicantIdentityAsync(ApplicantIdentityDto identity);
        Task<bool> DeleteApplicantIdentityAsync(string code);
    }
}