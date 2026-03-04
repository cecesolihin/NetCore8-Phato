using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.PersonalInformation.EmployeeSkill.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeSkill.Commands
{
    public class ExportEmployeeSkillCommandHandler : IRequestHandler<ExportEmployeeSkillCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IEmployeeSkillService employeeSkillService;

        public ExportEmployeeSkillCommandHandler(IEmployeeSkillService _employeeSkillService)
        {
            employeeSkillService = _employeeSkillService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportEmployeeSkillCommand request, CancellationToken cancellationToken)
        {
            return await employeeSkillService.ExportEmployeeSkillAsync(request.Type);
        }
    }
}
