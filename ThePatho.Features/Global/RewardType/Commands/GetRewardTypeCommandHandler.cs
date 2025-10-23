using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RewardType.Service;
using ThePatho.Features.Global.RewardType.DTO;

namespace ThePatho.Features.Global.RewardType.Commands
{
    public class GetRewardTypeCommandHandler : IRequestHandler<GetRewardTypeCommand, ApiResponse<RewardTypeItemDto>>
    {
        private readonly IRewardTypeService rewardTypeService;

        public GetRewardTypeCommandHandler(IRewardTypeService _rewardTypeService)
        {
            rewardTypeService = _rewardTypeService;
        }

        public async Task<ApiResponse<RewardTypeItemDto>> Handle(GetRewardTypeCommand request, CancellationToken cancellationToken)
        {
            return await rewardTypeService.GetRewardType(request);
        }
    }
}
