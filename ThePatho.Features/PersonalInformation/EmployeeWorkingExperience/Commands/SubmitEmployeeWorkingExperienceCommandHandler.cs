using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Commands
{
    public class SubmitEmployeeWorkingExperienceCommandHandler : IRequestHandler<SubmitEmployeeWorkingExperienceCommand, ApiResponse>
    {
        private readonly IEmployeeWorkingExperienceService Service;

        public SubmitEmployeeWorkingExperienceCommandHandler(IEmployeeWorkingExperienceService _employeeworkingexperienceService)
        {
            Service = _employeeworkingexperienceService;
        }

        public async Task<ApiResponse> Handle(SubmitEmployeeWorkingExperienceCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEmployeeWorkingExperience(request);
        }
    }
}

