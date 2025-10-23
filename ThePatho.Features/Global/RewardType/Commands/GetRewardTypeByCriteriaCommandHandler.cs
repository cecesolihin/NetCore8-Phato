using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RewardType.Service;
using ThePatho.Features.Global.RewardType.DTO;

namespace ThePatho.Features.Global.RewardType.Commands
{
    public class GetRewardTypeByCriteriaCommandHandler : IRequestHandler<GetRewardTypeByCriteriaCommand, ApiResponse<RewardTypeItemDto>>
    {
        private readonly IRewardTypeService rewardTypeService;

        public GetRewardTypeByCriteriaCommandHandler(IRewardTypeService _rewardTypeService)
        {
            rewardTypeService = _rewardTypeService;
        }

        public async Task<ApiResponse<RewardTypeItemDto>> Handle(GetRewardTypeByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await rewardTypeService.GetRewardTypeByCriteria(request);
        }
    }
}
