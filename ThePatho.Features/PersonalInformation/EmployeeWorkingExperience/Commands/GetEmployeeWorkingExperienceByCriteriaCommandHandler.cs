using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Service;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Commands
{
    public class GetEmployeeWorkingExperienceByCriteriaCommandHandler : IRequestHandler<GetEmployeeWorkingExperienceByCriteriaCommand, ApiResponse<EmployeeWorkingExperienceItemDto>>
    {
        private readonly IEmployeeWorkingExperienceService Service;

        public GetEmployeeWorkingExperienceByCriteriaCommandHandler(IEmployeeWorkingExperienceService _employeeworkingexperienceService)
        {
            Service = _employeeworkingexperienceService;
        }

        public async Task<ApiResponse<EmployeeWorkingExperienceItemDto>> Handle(GetEmployeeWorkingExperienceByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeWorkingExperienceByCriteria(request);
        }
    }
}

