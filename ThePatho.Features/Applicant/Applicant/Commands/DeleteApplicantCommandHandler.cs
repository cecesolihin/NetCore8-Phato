using MediatR;
using System;
using ThePatho.Features.Applicant.Applicant.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.Applicant.Commands
{
    public class DeleteApplicantCommandHandler : IRequestHandler<DeleteApplicantCommand, ApiResponse>
    {
        private readonly IApplicantService applicantService;

        public DeleteApplicantCommandHandler(IApplicantService _applicantService)
        {
            applicantService = _applicantService;
        }

        public async Task<ApiResponse> Handle(DeleteApplicantCommand request, CancellationToken cancellationToken)
        {
           return await applicantService.DeleteApplicant(request);
                
        }
    }
}
