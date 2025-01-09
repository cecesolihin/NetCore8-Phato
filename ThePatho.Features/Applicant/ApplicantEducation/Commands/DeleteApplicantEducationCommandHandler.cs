using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantEducation.Service;

namespace ThePatho.Features.Applicant.ApplicantEducation.Commands
{
    public class DeleteApplicantEducationCommandHandler : IRequestHandler<DeleteApplicantEducationCommand, bool>
    {
        private readonly IApplicantEducationService applicantEducationService;

        public DeleteApplicantEducationCommandHandler(IApplicantEducationService _applicantEducationService)
        {
            applicantEducationService = _applicantEducationService;
        }

        public async Task<bool> Handle(DeleteApplicantEducationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await applicantEducationService.DeleteApplicantEducation(request);
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
