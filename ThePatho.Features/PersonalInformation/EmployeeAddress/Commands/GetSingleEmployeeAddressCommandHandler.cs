using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeAddress.Service;
using ThePatho.Features.PersonalInformation.EmployeeAddress.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeAddress.Commands
{
    public class GetSingleEmployeeAddressCommandHandler : IRequestHandler<GetSingleEmployeeAddressCommand, ApiResponse<EmployeeAddressDto>>
    {
        private readonly IEmployeeAddressService Service;

        public GetSingleEmployeeAddressCommandHandler(IEmployeeAddressService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmployeeAddressDto>> Handle(GetSingleEmployeeAddressCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEmployeeAddress(request);
        }
    }
}
