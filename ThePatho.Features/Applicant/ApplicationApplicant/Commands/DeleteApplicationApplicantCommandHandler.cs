using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicationApplicant.Service;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Commands
{
    public class DeleteApplicationApplicantCommandHandler : IRequestHandler<DeleteApplicationApplicantCommand, bool>
    {
        private readonly IApplicationApplicantService applicationApplicantService;

        public DeleteApplicationApplicantCommandHandler(IApplicationApplicantService _applicationApplicantService)
        {
            applicationApplicantService = _applicationApplicantService;
        }

        public async Task<bool> Handle(DeleteApplicationApplicantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await applicationApplicantService.DeleteApplicationApplicant(request);
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
