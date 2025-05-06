using MediatR;
using ThePatho.Features.Applicant.ApplicationApplicant.DTO;
using ThePatho.Features.Applicant.ApplicationApplicant.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Commands
{
    public class GetApplicationApplicantCommandHandler : IRequestHandler<GetApplicationApplicantCommand, ApiResponse<ApplicationApplicantItemDto>>
    {
        private readonly IApplicationApplicantService applicationApplicantService; 
        public GetApplicationApplicantCommandHandler(IApplicationApplicantService _applicationApplicantService)
        {
            applicationApplicantService =_applicationApplicantService;
        }
        public async Task<ApiResponse<ApplicationApplicantItemDto>> Handle(GetApplicationApplicantCommand request, CancellationToken cancellationToken)
        {
            return await applicationApplicantService.GetApplicationApplicant(request);

        }
    }
}
