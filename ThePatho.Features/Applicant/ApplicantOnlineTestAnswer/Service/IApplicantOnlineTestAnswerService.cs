using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service
{
    public interface IApplicantOnlineTestAnswerService
    {
        Task<List<ApplicantOnlineTestAnswerDto>> GetApplicantOnlineTestAnswer(GetApplicantOnlineTestAnswerCommand request);
        Task<ApplicantOnlineTestAnswerDto> GetApplicantOnlineTestAnswerByCriteria(GetApplicantOnlineTestAnswerByCriteriaCommand request);
    }
}
