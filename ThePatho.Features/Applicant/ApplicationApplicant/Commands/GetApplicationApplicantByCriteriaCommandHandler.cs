using MediatR;
using ThePatho.Features.Applicant.ApplicationApplicant.DTO;
using ThePatho.Features.Applicant.ApplicationApplicant.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Commands
{
    public class GetApplicationApplicantByCriteriaCommandHandler : IRequestHandler<GetApplicationApplicantByCriteriaCommand, ApiResponse<ApplicationApplicantDto>>
    {
        private readonly IApplicationApplicantService applicationApplicantService; 
        public GetApplicationApplicantByCriteriaCommandHandler(IApplicationApplicantService _applicationApplicantService)
        {
            applicationApplicantService = _applicationApplicantService;
        }
        public async Task<ApiResponse<ApplicationApplicantDto>> Handle(GetApplicationApplicantByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicationApplicantService.GetApplicationApplicantByCriteria(request);

        }
    }
}
