using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RewardType.Service;

namespace ThePatho.Features.Global.RewardType.Commands
{
    public class SubmitRewardTypeCommandHandler : IRequestHandler<SubmitRewardTypeCommand, ApiResponse>
    {
        private readonly IRewardTypeService rewardTypeService;

        public SubmitRewardTypeCommandHandler(IRewardTypeService _rewardTypeService)
        {
            rewardTypeService = _rewardTypeService;
        }

        public async Task<ApiResponse> Handle(SubmitRewardTypeCommand request, CancellationToken cancellationToken)
        {
            return await rewardTypeService.SubmitRewardType(request);
        }
    }
}
