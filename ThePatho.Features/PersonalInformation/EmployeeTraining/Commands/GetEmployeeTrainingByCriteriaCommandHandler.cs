using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeTraining.Service;
using ThePatho.Features.PersonalInformation.EmployeeTraining.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeTraining.Commands
{
    public class GetEmployeeTrainingByCriteriaCommandHandler : IRequestHandler<GetEmployeeTrainingByCriteriaCommand, ApiResponse<EmployeeTrainingItemDto>>
    {
        private readonly IEmployeeTrainingService Service;

        public GetEmployeeTrainingByCriteriaCommandHandler(IEmployeeTrainingService _employeetrainingService)
        {
            Service = _employeetrainingService;
        }

        public async Task<ApiResponse<EmployeeTrainingItemDto>> Handle(GetEmployeeTrainingByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeTrainingByCriteria(request);
        }
    }
}

