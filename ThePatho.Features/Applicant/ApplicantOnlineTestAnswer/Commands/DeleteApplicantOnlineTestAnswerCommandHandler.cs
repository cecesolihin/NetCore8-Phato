using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class DeleteApplicantOnlineTestAnswerCommandHandler : IRequestHandler<DeleteApplicantOnlineTestAnswerCommand, ApiResponse>
    {
        private readonly IApplicantOnlineTestAnswerService applicantOnlineTestAnswerService;

        public DeleteApplicantOnlineTestAnswerCommandHandler(IApplicantOnlineTestAnswerService _applicantOnlineTestAnswerService)
        {
            applicantOnlineTestAnswerService = _applicantOnlineTestAnswerService;
        }

        public async Task<ApiResponse> Handle(DeleteApplicantOnlineTestAnswerCommand request, CancellationToken cancellationToken)
        {
            return await applicantOnlineTestAnswerService.DeleteApplicantOnlineTestAnswer(request);
                
        }
    }
}
