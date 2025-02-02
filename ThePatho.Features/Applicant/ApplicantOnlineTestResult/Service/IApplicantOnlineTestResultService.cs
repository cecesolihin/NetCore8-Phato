using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service
{
    public interface IApplicantOnlineTestResultService
    {
        Task<NewApiResponse<ApplicantOnlineTestResultItemDto>> GetApplicantOnlineTestResult(GetApplicantOnlineTestResultCommand request); 
        Task<NewApiResponse<ApplicantOnlineTestResultDto>> GetApplicantOnlineTestResultByCriteria(GetApplicantOnlineTestResultByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantOnlineTestResult(SubmitApplicantOnlineTestResultCommand request);
        Task<ApiResponse> DeleteApplicantOnlineTestResult(DeleteApplicantOnlineTestResultCommand request);
    }
}
