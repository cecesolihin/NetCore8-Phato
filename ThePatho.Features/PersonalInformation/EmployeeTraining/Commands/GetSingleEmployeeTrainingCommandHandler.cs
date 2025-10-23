using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeTraining.Service;
using ThePatho.Features.PersonalInformation.EmployeeTraining.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeTraining.Commands
{
    public class GetSingleEmployeeTrainingCommandHandler : IRequestHandler<GetSingleEmployeeTrainingCommand, ApiResponse<EmployeeTrainingDto>>
    {
        private readonly IEmployeeTrainingService Service;

        public GetSingleEmployeeTrainingCommandHandler(IEmployeeTrainingService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmployeeTrainingDto>> Handle(GetSingleEmployeeTrainingCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEmployeeTraining(request);
        }
    }
}
