using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service
{
    public interface IApplicantOnlineTestAnswerService
    {
        Task<NewApiResponse<ApplicantOnlineTestAnswerItemDto>> GetApplicantOnlineTestAnswer(GetApplicantOnlineTestAnswerCommand request);
        Task<NewApiResponse<ApplicantOnlineTestAnswerDto>> GetApplicantOnlineTestAnswerByCriteria(GetApplicantOnlineTestAnswerByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantOnlineTestAnswer(SubmitApplicantOnlineTestAnswerCommand request);
        Task<ApiResponse> DeleteApplicantOnlineTestAnswer(DeleteApplicantOnlineTestAnswerCommand request);
    }
}
