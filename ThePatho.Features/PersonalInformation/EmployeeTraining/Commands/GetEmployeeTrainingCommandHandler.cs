using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeTraining.Service;
using ThePatho.Features.PersonalInformation.EmployeeTraining.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeTraining.Commands
{
    public class GetEmployeeTrainingCommandHandler : IRequestHandler<GetEmployeeTrainingCommand, ApiResponse<EmployeeTrainingItemDto>>
    {
        private readonly IEmployeeTrainingService Service;

        public GetEmployeeTrainingCommandHandler(IEmployeeTrainingService _employeetrainingService)
        {
            Service = _employeetrainingService;
        }

        public async Task<ApiResponse<EmployeeTrainingItemDto>> Handle(GetEmployeeTrainingCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeTraining(request);
        }
    }
}

