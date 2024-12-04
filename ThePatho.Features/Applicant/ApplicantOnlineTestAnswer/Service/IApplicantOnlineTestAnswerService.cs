using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service
{
    public interface IApplicantOnlineTestAnswerService
    {
        Task<List<ApplicantOnlineTestAnswerDto>> GetAllApplicantOnlineTestAnswersAsync();
        Task<ApplicantOnlineTestAnswerDto?> GetApplicantOnlineTestAnswerByCodeAsync(string code);
        Task<ApplicantOnlineTestAnswerDto> AddApplicantOnlineTestAnswerAsync(ApplicantOnlineTestAnswerDto answer);
        Task<ApplicantOnlineTestAnswerDto?> UpdateApplicantOnlineTestAnswerAsync(ApplicantOnlineTestAnswerDto answer);
        Task<bool> DeleteApplicantOnlineTestAnswerAsync(string code);
    }
}
