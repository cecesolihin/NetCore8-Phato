using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RewardType.Service;
using ThePatho.Features.Global.RewardType.DTO;

namespace ThePatho.Features.Global.RewardType.Commands
{
    public class GetSingleRewardTypeCommandHandler : IRequestHandler<GetSingleRewardTypeCommand, ApiResponse<RewardTypeDto>>
    {
        private readonly IRewardTypeService Service;

        public GetSingleRewardTypeCommandHandler(IRewardTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<RewardTypeDto>> Handle(GetSingleRewardTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleRewardType(request);
        }
    }
}
