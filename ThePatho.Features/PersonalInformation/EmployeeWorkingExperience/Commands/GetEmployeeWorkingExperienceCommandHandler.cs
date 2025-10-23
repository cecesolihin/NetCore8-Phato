using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Service;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Commands
{
    public class GetEmployeeWorkingExperienceCommandHandler : IRequestHandler<GetEmployeeWorkingExperienceCommand, ApiResponse<EmployeeWorkingExperienceItemDto>>
    {
        private readonly IEmployeeWorkingExperienceService Service;

        public GetEmployeeWorkingExperienceCommandHandler(IEmployeeWorkingExperienceService _employeeworkingexperienceService)
        {
            Service = _employeeworkingexperienceService;
        }

        public async Task<ApiResponse<EmployeeWorkingExperienceItemDto>> Handle(GetEmployeeWorkingExperienceCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeWorkingExperience(request);
        }
    }
}

