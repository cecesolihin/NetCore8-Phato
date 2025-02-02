using MediatR;
using ThePatho.Features.Applicant.ApplicationApplicant.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Commands
{
    public class SubmitApplicationApplicantCommandHandler : IRequestHandler<SubmitApplicationApplicantCommand, ApiResponse>
    {
        private readonly IApplicationApplicantService ApplicationApplicantService;

        public SubmitApplicationApplicantCommandHandler(IApplicationApplicantService _ApplicationApplicantService)
        {
            ApplicationApplicantService = _ApplicationApplicantService;
        }

        public async Task<ApiResponse> Handle(SubmitApplicationApplicantCommand request, CancellationToken cancellationToken)
        {
            return await ApplicationApplicantService.SubmitApplicationApplicant(request);
          
        }
    }
}
