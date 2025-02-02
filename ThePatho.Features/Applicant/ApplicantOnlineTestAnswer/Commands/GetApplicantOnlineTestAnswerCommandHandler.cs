using MediatR;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class GetApplicantOnlineTestAnswerCommandHandler : IRequestHandler<GetApplicantOnlineTestAnswerCommand, NewApiResponse<ApplicantOnlineTestAnswerItemDto>>
    {
        private readonly IApplicantOnlineTestAnswerService applicantOnlineTestAnswerService;
        public GetApplicantOnlineTestAnswerCommandHandler(IApplicantOnlineTestAnswerService _applicantOnlineTestAnswerService)
        {
            applicantOnlineTestAnswerService =_applicantOnlineTestAnswerService;
        } 
        public async Task<NewApiResponse<ApplicantOnlineTestAnswerItemDto>> Handle(GetApplicantOnlineTestAnswerCommand request, CancellationToken cancellationToken)
        {
            return await applicantOnlineTestAnswerService.GetApplicantOnlineTestAnswer(request);

        }
    }
}
