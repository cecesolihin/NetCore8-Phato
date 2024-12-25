using MediatR;
using ThePatho.Features.Applicant.ApplicationApplicant.DTO;
using ThePatho.Features.Applicant.ApplicationApplicant.Service;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Commands
{
    public class GetApplicationApplicantCommandHandler : IRequestHandler<GetApplicationApplicantCommand, ApplicationApplicantItemDto>
    {
        private readonly IApplicationApplicantService applicationApplicantService; 
        public GetApplicationApplicantCommandHandler(IApplicationApplicantService _applicationApplicantService)
        {
            applicationApplicantService =_applicationApplicantService;
        }
        public async Task<ApplicationApplicantItemDto> Handle(GetApplicationApplicantCommand request, CancellationToken cancellationToken)
        {
            var data = await applicationApplicantService.GetApplicationApplicant(request);

            return new ApplicationApplicantItemDto
            {
                DataOfRecords = data.Count,
                ApplicationApplicantList = data,
            };
        }
    }
}
