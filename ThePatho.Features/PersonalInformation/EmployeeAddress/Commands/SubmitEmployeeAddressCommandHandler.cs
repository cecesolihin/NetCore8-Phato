using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeAddress.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeAddress.Commands
{
    public class SubmitEmployeeAddressCommandHandler : IRequestHandler<SubmitEmployeeAddressCommand, ApiResponse>
    {
        private readonly IEmployeeAddressService Service;

        public SubmitEmployeeAddressCommandHandler(IEmployeeAddressService _employeeaddressService)
        {
            Service = _employeeaddressService;
        }

        public async Task<ApiResponse> Handle(SubmitEmployeeAddressCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEmployeeAddress(request);
        }
    }
}

