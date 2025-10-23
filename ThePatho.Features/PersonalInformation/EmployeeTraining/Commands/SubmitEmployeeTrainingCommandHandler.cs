using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeTraining.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeTraining.Commands
{
    public class SubmitEmployeeTrainingCommandHandler : IRequestHandler<SubmitEmployeeTrainingCommand, ApiResponse>
    {
        private readonly IEmployeeTrainingService Service;

        public SubmitEmployeeTrainingCommandHandler(IEmployeeTrainingService _employeetrainingService)
        {
            Service = _employeetrainingService;
        }

        public async Task<ApiResponse> Handle(SubmitEmployeeTrainingCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEmployeeTraining(request);
        }
    }
}

