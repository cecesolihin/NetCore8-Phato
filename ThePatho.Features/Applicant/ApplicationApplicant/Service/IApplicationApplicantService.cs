using ThePatho.Features.Applicant.ApplicationApplicant.Commands;
using ThePatho.Features.Applicant.ApplicationApplicant.DTO;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Service
{
    public interface IApplicationApplicantService
    {
        Task<List<ApplicationApplicantDto>> GetApplicationApplicant(GetApplicationApplicantCommand request);
        Task<ApplicationApplicantDto> GetApplicationApplicantByCriteria(GetApplicationApplicantByCriteriaCommand request); 
    }
}
