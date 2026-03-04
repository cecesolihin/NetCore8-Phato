using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Commands
{
    public class ExportEmployeeWorkingExperienceCommandHandler : IRequestHandler<ExportEmployeeWorkingExperienceCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IEmployeeWorkingExperienceService employeeWorkingExperienceService;

        public ExportEmployeeWorkingExperienceCommandHandler(IEmployeeWorkingExperienceService _employeeWorkingExperienceService)
        {
            employeeWorkingExperienceService = _employeeWorkingExperienceService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportEmployeeWorkingExperienceCommand request, CancellationToken cancellationToken)
        {
            return await employeeWorkingExperienceService.ExportEmployeeWorkingExperienceAsync(request.Type);
        }
    }
}
