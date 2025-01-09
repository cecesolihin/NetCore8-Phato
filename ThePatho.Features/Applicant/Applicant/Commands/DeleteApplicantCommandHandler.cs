using MediatR;
using System;
using ThePatho.Features.Applicant.Applicant.Service;

namespace ThePatho.Features.Applicant.Applicant.Commands
{
    public class DeleteApplicantCommandHandler : IRequestHandler<DeleteApplicantCommand, bool>
    {
        private readonly IApplicantService applicantService;

        public DeleteApplicantCommandHandler(IApplicantService _applicantService)
        {
            applicantService = _applicantService;
        }

        public async Task<bool> Handle(DeleteApplicantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await applicantService.DeleteApplicant(request);
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
