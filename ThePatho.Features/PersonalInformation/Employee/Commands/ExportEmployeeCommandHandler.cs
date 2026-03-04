using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.PersonalInformation.Employee.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.Employee.Commands
{
    public class ExportEmployeeCommandHandler : IRequestHandler<ExportEmployeeCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IEmployeeService employeeService;

        public ExportEmployeeCommandHandler(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeService.ExportEmployeeAsync(request.Type);
        }
    }
}
