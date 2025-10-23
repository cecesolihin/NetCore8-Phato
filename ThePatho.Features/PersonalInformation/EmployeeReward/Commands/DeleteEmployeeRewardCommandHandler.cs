using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeReward.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeReward.Commands
{
    public class DeleteEmployeeRewardCommandHandler : IRequestHandler<DeleteEmployeeRewardCommand, ApiResponse>
    {
        private readonly IEmployeeRewardService Service;

        public DeleteEmployeeRewardCommandHandler(IEmployeeRewardService _employeerewardService)
        {
            Service = _employeerewardService;
        }

        public async Task<ApiResponse> Handle(DeleteEmployeeRewardCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteEmployeeReward(request);
        }
    }
}

