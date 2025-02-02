using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicationApplicant.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Commands
{
    public class DeleteApplicationApplicantCommandHandler : IRequestHandler<DeleteApplicationApplicantCommand, ApiResponse>
    {
        private readonly IApplicationApplicantService applicationApplicantService;

        public DeleteApplicationApplicantCommandHandler(IApplicationApplicantService _applicationApplicantService)
        {
            applicationApplicantService = _applicationApplicantService;
        }

        public async Task<ApiResponse> Handle(DeleteApplicationApplicantCommand request, CancellationToken cancellationToken)
        {
            return await applicationApplicantService.DeleteApplicationApplicant(request);
        }
    }
}
