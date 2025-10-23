using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeReward.Service;
using ThePatho.Features.PersonalInformation.EmployeeReward.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeReward.Commands
{
    public class GetEmployeeRewardCommandHandler : IRequestHandler<GetEmployeeRewardCommand, ApiResponse<EmployeeRewardItemDto>>
    {
        private readonly IEmployeeRewardService Service;

        public GetEmployeeRewardCommandHandler(IEmployeeRewardService _employeerewardService)
        {
            Service = _employeerewardService;
        }

        public async Task<ApiResponse<EmployeeRewardItemDto>> Handle(GetEmployeeRewardCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeReward(request);
        }
    }
}

