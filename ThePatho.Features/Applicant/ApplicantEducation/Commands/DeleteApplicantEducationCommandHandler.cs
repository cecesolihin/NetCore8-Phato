using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantEducation.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantEducation.Commands
{
    public class DeleteApplicantEducationCommandHandler : IRequestHandler<DeleteApplicantEducationCommand, ApiResponse>
    {
        private readonly IApplicantEducationService applicantEducationService;

        public DeleteApplicantEducationCommandHandler(IApplicantEducationService _applicantEducationService)
        {
            applicantEducationService = _applicantEducationService;
        }

        public async Task<ApiResponse> Handle(DeleteApplicantEducationCommand request, CancellationToken cancellationToken)
        {
            return await applicantEducationService.DeleteApplicantEducation(request);
                
        }
    }
}
