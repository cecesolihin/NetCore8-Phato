using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeReward.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeReward.Commands
{
    public class SubmitEmployeeRewardCommandHandler : IRequestHandler<SubmitEmployeeRewardCommand, ApiResponse>
    {
        private readonly IEmployeeRewardService Service;

        public SubmitEmployeeRewardCommandHandler(IEmployeeRewardService _employeerewardService)
        {
            Service = _employeerewardService;
        }

        public async Task<ApiResponse> Handle(SubmitEmployeeRewardCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEmployeeReward(request);
        }
    }
}

