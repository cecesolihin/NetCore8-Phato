using ThePatho.Features.Applicant.ApplicantOnlineTestResult.DTO;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service
{
    public interface IApplicantOnlineTestResultService
    {
        Task<List<ApplicantOnlineTestResultDto>> GetAllApplicantOnlineTestResultsAsync();
        Task<ApplicantOnlineTestResultDto?> GetApplicantOnlineTestResultByCodeAsync(string code);
        Task<ApplicantOnlineTestResultDto> AddApplicantOnlineTestResultAsync(ApplicantOnlineTestResultDto result);
        Task<ApplicantOnlineTestResultDto?> UpdateApplicantOnlineTestResultAsync(ApplicantOnlineTestResultDto result);
        Task<bool> DeleteApplicantOnlineTestResultAsync(string code);
    }
}
