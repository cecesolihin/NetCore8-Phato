using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.PersonalInformation.EmployeeFamily.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeFamily.Commands
{
    public class ExportEmployeeFamilyCommandHandler : IRequestHandler<ExportEmployeeFamilyCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IEmployeeFamilyService employeeFamilyService;

        public ExportEmployeeFamilyCommandHandler(IEmployeeFamilyService _employeeFamilyService)
        {
            employeeFamilyService = _employeeFamilyService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportEmployeeFamilyCommand request, CancellationToken cancellationToken)
        {
            return await employeeFamilyService.ExportEmployeeFamilyAsync(request.Type);
        }
    }
}
