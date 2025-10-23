using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.Service;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.Commands
{
    public class GetEmployeeIdentityByCriteriaCommandHandler : IRequestHandler<GetEmployeeIdentityByCriteriaCommand, ApiResponse<EmployeeIdentityItemDto>>
    {
        private readonly IEmployeeIdentityService Service;

        public GetEmployeeIdentityByCriteriaCommandHandler(IEmployeeIdentityService _employeeidentityService)
        {
            Service = _employeeidentityService;
        }

        public async Task<ApiResponse<EmployeeIdentityItemDto>> Handle(GetEmployeeIdentityByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeIdentityByCriteria(request);
        }
    }
}

