using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.PersonalInformation.EmployeeAddress.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeAddress.Commands
{
    public class ExportEmployeeAddressCommandHandler : IRequestHandler<ExportEmployeeAddressCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IEmployeeAddressService employeeAddressService;

        public ExportEmployeeAddressCommandHandler(IEmployeeAddressService _employeeAddressService)
        {
            employeeAddressService = _employeeAddressService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportEmployeeAddressCommand request, CancellationToken cancellationToken)
        {
            return await employeeAddressService.ExportEmployeeAddressAsync(request.Type);
        }
    }
}
