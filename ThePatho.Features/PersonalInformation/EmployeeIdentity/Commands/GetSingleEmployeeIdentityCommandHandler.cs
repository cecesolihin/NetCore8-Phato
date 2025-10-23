using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.Service;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.Commands
{
    public class GetSingleEmployeeIdentityCommandHandler : IRequestHandler<GetSingleEmployeeIdentityCommand, ApiResponse<EmployeeIdentityDto>>
    {
        private readonly IEmployeeIdentityService Service;

        public GetSingleEmployeeIdentityCommandHandler(IEmployeeIdentityService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmployeeIdentityDto>> Handle(GetSingleEmployeeIdentityCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEmployeeIdentity(request);
        }
    }
}
