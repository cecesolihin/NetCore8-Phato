using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeePickUp.Service;
using ThePatho.Features.PersonalInformation.EmployeePickUp.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeePickUp.Commands
{
    public class GetEmployeePickUpCommandHandler : IRequestHandler<GetEmployeePickUpCommand, ApiResponse<EmployeePickUpItemDto>>
    {
        private readonly IEmployeePickUpService Service;

        public GetEmployeePickUpCommandHandler(IEmployeePickUpService _employeepickupService)
        {
            Service = _employeepickupService;
        }

        public async Task<ApiResponse<EmployeePickUpItemDto>> Handle(GetEmployeePickUpCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeePickUp(request);
        }
    }
}

