using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RewardType.Service;

namespace ThePatho.Features.Global.RewardType.Commands
{
    public class DeleteRewardTypeCommandHandler : IRequestHandler<DeleteRewardTypeCommand, ApiResponse>
    {
        private readonly IRewardTypeService rewardTypeService;

        public DeleteRewardTypeCommandHandler(IRewardTypeService _rewardTypeService)
        {
            rewardTypeService = _rewardTypeService;
        }

        public async Task<ApiResponse> Handle(DeleteRewardTypeCommand request, CancellationToken cancellationToken)
        {
            return await rewardTypeService.DeleteRewardType(request);
        }
    }
}
