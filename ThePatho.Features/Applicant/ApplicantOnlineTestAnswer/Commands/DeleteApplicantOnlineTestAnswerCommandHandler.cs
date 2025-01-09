using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class DeleteApplicantOnlineTestAnswerCommandHandler : IRequestHandler<DeleteApplicantOnlineTestAnswerCommand, bool>
    {
        private readonly IApplicantOnlineTestAnswerService applicantOnlineTestAnswerService;

        public DeleteApplicantOnlineTestAnswerCommandHandler(IApplicantOnlineTestAnswerService _applicantOnlineTestAnswerService)
        {
            applicantOnlineTestAnswerService = _applicantOnlineTestAnswerService;
        }

        public async Task<bool> Handle(DeleteApplicantOnlineTestAnswerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await applicantOnlineTestAnswerService.DeleteApplicantOnlineTestAnswer(request);
                return true;
            }
            catch
            {
                // Log the error here if needed
                return false;
            }
        }
    }
}
