using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.Service;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.Commands
{
    public class GetEmployeeIdentityCommandHandler : IRequestHandler<GetEmployeeIdentityCommand, ApiResponse<EmployeeIdentityItemDto>>
    {
        private readonly IEmployeeIdentityService Service;

        public GetEmployeeIdentityCommandHandler(IEmployeeIdentityService _employeeidentityService)
        {
            Service = _employeeidentityService;
        }

        public async Task<ApiResponse<EmployeeIdentityItemDto>> Handle(GetEmployeeIdentityCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeIdentity(request);
        }
    }
}

