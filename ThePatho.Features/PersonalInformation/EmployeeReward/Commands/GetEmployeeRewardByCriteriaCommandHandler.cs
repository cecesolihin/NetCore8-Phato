using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeReward.Service;
using ThePatho.Features.PersonalInformation.EmployeeReward.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeReward.Commands
{
    public class GetEmployeeRewardByCriteriaCommandHandler : IRequestHandler<GetEmployeeRewardByCriteriaCommand, ApiResponse<EmployeeRewardItemDto>>
    {
        private readonly IEmployeeRewardService Service;

        public GetEmployeeRewardByCriteriaCommandHandler(IEmployeeRewardService _employeerewardService)
        {
            Service = _employeerewardService;
        }

        public async Task<ApiResponse<EmployeeRewardItemDto>> Handle(GetEmployeeRewardByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeRewardByCriteria(request);
        }
    }
}

