using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.PersonalInformation.EmployeeEducation.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeEducation.Commands
{
    public class ExportEmployeeEducationCommandHandler : IRequestHandler<ExportEmployeeEducationCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IEmployeeEducationService employeeEducationService;

        public ExportEmployeeEducationCommandHandler(IEmployeeEducationService _employeeEducationService)
        {
            employeeEducationService = _employeeEducationService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportEmployeeEducationCommand request, CancellationToken cancellationToken)
        {
            return await employeeEducationService.ExportEmployeeEducationAsync(request.Type);
        }
    }
}
