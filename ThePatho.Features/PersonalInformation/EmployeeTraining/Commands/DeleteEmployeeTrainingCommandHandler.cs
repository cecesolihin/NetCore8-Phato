using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeTraining.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeTraining.Commands
{
    public class DeleteEmployeeTrainingCommandHandler : IRequestHandler<DeleteEmployeeTrainingCommand, ApiResponse>
    {
        private readonly IEmployeeTrainingService Service;

        public DeleteEmployeeTrainingCommandHandler(IEmployeeTrainingService _employeetrainingService)
        {
            Service = _employeetrainingService;
        }

        public async Task<ApiResponse> Handle(DeleteEmployeeTrainingCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteEmployeeTraining(request);
        }
    }
}

