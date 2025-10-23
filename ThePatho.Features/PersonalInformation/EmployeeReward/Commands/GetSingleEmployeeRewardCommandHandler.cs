using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeReward.Service;
using ThePatho.Features.PersonalInformation.EmployeeReward.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeReward.Commands
{
    public class GetSingleEmployeeRewardCommandHandler : IRequestHandler<GetSingleEmployeeRewardCommand, ApiResponse<EmployeeRewardDto>>
    {
        private readonly IEmployeeRewardService Service;

        public GetSingleEmployeeRewardCommandHandler(IEmployeeRewardService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmployeeRewardDto>> Handle(GetSingleEmployeeRewardCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEmployeeReward(request);
        }
    }
}
