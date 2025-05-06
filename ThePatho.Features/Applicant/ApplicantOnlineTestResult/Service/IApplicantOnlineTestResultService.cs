using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service
{
    public interface IApplicantOnlineTestResultService
    {
        Task<ApiResponse<ApplicantOnlineTestResultItemDto>> GetApplicantOnlineTestResult(GetApplicantOnlineTestResultCommand request); 
        Task<ApiResponse<ApplicantOnlineTestResultDto>> GetApplicantOnlineTestResultByCriteria(GetApplicantOnlineTestResultByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantOnlineTestResult(SubmitApplicantOnlineTestResultCommand request);
        Task<ApiResponse> DeleteApplicantOnlineTestResult(DeleteApplicantOnlineTestResultCommand request);
    }
}
