using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Commands
{
    public class DeleteEmployeeWorkingExperienceCommandHandler : IRequestHandler<DeleteEmployeeWorkingExperienceCommand, ApiResponse>
    {
        private readonly IEmployeeWorkingExperienceService Service;

        public DeleteEmployeeWorkingExperienceCommandHandler(IEmployeeWorkingExperienceService _employeeworkingexperienceService)
        {
            Service = _employeeworkingexperienceService;
        }

        public async Task<ApiResponse> Handle(DeleteEmployeeWorkingExperienceCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteEmployeeWorkingExperience(request);
        }
    }
}

