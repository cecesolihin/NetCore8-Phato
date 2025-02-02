using MediatR;
using ThePatho.Features.Applicant.ApplicantEducation.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantEducation.Commands
{
    public class SubmitApplicantEducationCommandHandler : IRequestHandler<SubmitApplicantEducationCommand, ApiResponse>
    {
        private readonly IApplicantEducationService applicantEducationService;

        public SubmitApplicantEducationCommandHandler(IApplicantEducationService _applicantEducationService)
        {
            applicantEducationService = _applicantEducationService;
        }

        public async Task<ApiResponse> Handle(SubmitApplicantEducationCommand request, CancellationToken cancellationToken)
        {
            return await applicantEducationService.SubmitApplicantEducation(request);
           
        }
    }
}
