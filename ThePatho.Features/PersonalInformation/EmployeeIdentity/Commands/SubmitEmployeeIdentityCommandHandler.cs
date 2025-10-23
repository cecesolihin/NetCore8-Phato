using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.Commands
{
    public class SubmitEmployeeIdentityCommandHandler : IRequestHandler<SubmitEmployeeIdentityCommand, ApiResponse>
    {
        private readonly IEmployeeIdentityService Service;

        public SubmitEmployeeIdentityCommandHandler(IEmployeeIdentityService _employeeidentityService)
        {
            Service = _employeeidentityService;
        }

        public async Task<ApiResponse> Handle(SubmitEmployeeIdentityCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEmployeeIdentity(request);
        }
    }
}

