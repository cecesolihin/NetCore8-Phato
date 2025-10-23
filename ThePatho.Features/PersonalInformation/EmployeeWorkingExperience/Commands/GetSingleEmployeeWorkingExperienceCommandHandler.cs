using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Service;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Commands
{
    public class GetSingleEmployeeWorkingExperienceCommandHandler : IRequestHandler<GetSingleEmployeeWorkingExperienceCommand, ApiResponse<EmployeeWorkingExperienceDto>>
    {
        private readonly IEmployeeWorkingExperienceService Service;

        public GetSingleEmployeeWorkingExperienceCommandHandler(IEmployeeWorkingExperienceService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmployeeWorkingExperienceDto>> Handle(GetSingleEmployeeWorkingExperienceCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEmployeeWorkingExperience(request);
        }
    }
}
