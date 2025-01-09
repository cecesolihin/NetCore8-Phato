using ThePatho.Features.Applicant.Applicant.DTO;
using ThePatho.Features.Applicant.Applicant.Commands;

namespace ThePatho.Features.Applicant.Applicant.Service
{
    public interface IApplicantService
    {
        Task<List<ApplicantDto>> GetApplicant(GetApplicantCommand request);
        Task<ApplicantDto> GetApplicantByCriteria(GetApplicantByCriteriaCommand request);
        Task<bool> SubmitApplicant(SubmitApplicantCommand request);
        Task<bool> DeleteApplicant(DeleteApplicantCommand request);
    }
}
