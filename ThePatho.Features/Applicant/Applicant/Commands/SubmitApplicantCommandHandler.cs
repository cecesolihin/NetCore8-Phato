using MediatR;
using ThePatho.Features.Applicant.Applicant.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.Applicant.Commands
{
    public class SubmitApplicantCommandHandler : IRequestHandler<SubmitApplicantCommand, ApiResponse>
    {
        private readonly IApplicantService applicantService;

        public SubmitApplicantCommandHandler(IApplicantService _applicantService)
        {
            applicantService = _applicantService;
        }

        public async Task<ApiResponse> Handle(SubmitApplicantCommand request, CancellationToken cancellationToken)
        {
            return await applicantService.SubmitApplicant(request);
            
        }
    }
}
