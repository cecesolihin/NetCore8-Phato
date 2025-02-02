using MediatR;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class GetApplicantOnlineTestAnswerByCriteriaCommandHandler : IRequestHandler<GetApplicantOnlineTestAnswerByCriteriaCommand, NewApiResponse<ApplicantOnlineTestAnswerDto>>
    {
        private readonly IApplicantOnlineTestAnswerService applicantOnlineTestAnswerService;
        public GetApplicantOnlineTestAnswerByCriteriaCommandHandler(IApplicantOnlineTestAnswerService _applicantOnlineTestAnswerService)
        {
            applicantOnlineTestAnswerService = _applicantOnlineTestAnswerService; 
        }
        public async Task<NewApiResponse<ApplicantOnlineTestAnswerDto>> Handle(GetApplicantOnlineTestAnswerByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantOnlineTestAnswerService.GetApplicantOnlineTestAnswerByCriteria(request);

        }
    }
}
