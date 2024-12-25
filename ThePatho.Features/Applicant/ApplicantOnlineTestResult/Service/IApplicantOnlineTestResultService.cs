using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.DTO;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service
{
    public interface IApplicantOnlineTestResultService
    {
        Task<List<ApplicantOnlineTestResultDto>> GetApplicantOnlineTestResult(GetApplicantOnlineTestResultCommand request); 
        Task<ApplicantOnlineTestResultDto> GetApplicantOnlineTestResultByCriteria(GetApplicantOnlineTestResultByCriteriaCommand request);
    }
}
