using MediatR;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class GetApplicantOnlineTestAnswerCommandHandler : IRequestHandler<GetApplicantOnlineTestAnswerCommand, ApplicantOnlineTestAnswerItemDto>
    {
        private readonly IApplicantOnlineTestAnswerService applicantOnlineTestAnswerService;
        public GetApplicantOnlineTestAnswerCommandHandler(IApplicantOnlineTestAnswerService _applicantOnlineTestAnswerService)
        {
            applicantOnlineTestAnswerService =_applicantOnlineTestAnswerService;
        } 
        public async Task<ApplicantOnlineTestAnswerItemDto> Handle(GetApplicantOnlineTestAnswerCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantOnlineTestAnswerService.GetApplicantOnlineTestAnswer(request);

            return new ApplicantOnlineTestAnswerItemDto
            {
                DataOfRecords = data.Count,
                ApplicantOnlineTestAnswerList = data,
            };
        }
    }
}
