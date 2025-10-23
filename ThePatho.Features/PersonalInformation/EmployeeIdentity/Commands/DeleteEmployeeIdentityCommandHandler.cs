using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.Commands
{
    public class DeleteEmployeeIdentityCommandHandler : IRequestHandler<DeleteEmployeeIdentityCommand, ApiResponse>
    {
        private readonly IEmployeeIdentityService Service;

        public DeleteEmployeeIdentityCommandHandler(IEmployeeIdentityService _employeeidentityService)
        {
            Service = _employeeidentityService;
        }

        public async Task<ApiResponse> Handle(DeleteEmployeeIdentityCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteEmployeeIdentity(request);
        }
    }
}

