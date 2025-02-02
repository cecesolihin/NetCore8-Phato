using MediatR;
using ThePatho.Features.Applicant.ApplicationApplicant.DTO;
using ThePatho.Features.Applicant.ApplicationApplicant.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Commands
{
    public class GetApplicationApplicantCommandHandler : IRequestHandler<GetApplicationApplicantCommand, NewApiResponse<ApplicationApplicantItemDto>>
    {
        private readonly IApplicationApplicantService applicationApplicantService; 
        public GetApplicationApplicantCommandHandler(IApplicationApplicantService _applicationApplicantService)
        {
            applicationApplicantService =_applicationApplicantService;
        }
        public async Task<NewApiResponse<ApplicationApplicantItemDto>> Handle(GetApplicationApplicantCommand request, CancellationToken cancellationToken)
        {
            return await applicationApplicantService.GetApplicationApplicant(request);

        }
    }
}
