using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service
{
    public interface IApplicantOnlineTestAnswerService
    {
        Task<ApiResponse<ApplicantOnlineTestAnswerItemDto>> GetApplicantOnlineTestAnswer(GetApplicantOnlineTestAnswerCommand request);
        Task<ApiResponse<ApplicantOnlineTestAnswerDto>> GetApplicantOnlineTestAnswerByCriteria(GetApplicantOnlineTestAnswerByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantOnlineTestAnswer(SubmitApplicantOnlineTestAnswerCommand request);
        Task<ApiResponse> DeleteApplicantOnlineTestAnswer(DeleteApplicantOnlineTestAnswerCommand request);
    }
}
