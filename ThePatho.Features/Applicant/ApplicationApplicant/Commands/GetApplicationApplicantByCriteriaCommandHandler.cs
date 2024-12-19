using MediatR;
using ThePatho.Features.Applicant.ApplicationApplicant.DTO;
using ThePatho.Features.Applicant.ApplicationApplicant.Service;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Commands
{
    public class GetApplicationApplicantByCriteriaCommandHandler : IRequestHandler<GetApplicationApplicantByCriteriaCommand, ApplicationApplicantDto>
    {
        private readonly IApplicationApplicantService applicationApplicantService;
        public GetApplicationApplicantByCriteriaCommandHandler(IApplicationApplicantService _applicationApplicantService)
        {
            applicationApplicantService = _applicationApplicantService;
        }
        public async Task<ApplicationApplicantDto> Handle(GetApplicationApplicantByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await applicationApplicantService.GetApplicationApplicantByCriteria(request);

            return data;
        }
    }
}
