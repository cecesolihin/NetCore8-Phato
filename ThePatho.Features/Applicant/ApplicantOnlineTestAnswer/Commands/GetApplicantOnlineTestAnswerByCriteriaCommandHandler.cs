using MediatR;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class GetApplicantOnlineTestAnswerByCriteriaCommandHandler : IRequestHandler<GetApplicantOnlineTestAnswerByCriteriaCommand, ApplicantOnlineTestAnswerDto>
    {
        private readonly IApplicantOnlineTestAnswerService applicantOnlineTestAnswerService;
        public GetApplicantOnlineTestAnswerByCriteriaCommandHandler(IApplicantOnlineTestAnswerService _applicantOnlineTestAnswerService)
        {
            applicantOnlineTestAnswerService = _applicantOnlineTestAnswerService; 
        }
        public async Task<ApplicantOnlineTestAnswerDto> Handle(GetApplicantOnlineTestAnswerByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantOnlineTestAnswerService.GetApplicantOnlineTestAnswerByCriteria(request);

            return data;
        }
    }
}
