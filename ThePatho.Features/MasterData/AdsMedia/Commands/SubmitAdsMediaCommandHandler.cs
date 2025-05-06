using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsMedia.Service;

namespace ThePatho.Features.MasterData.AdsMedia.Commands
{
    public class SubmitAdsMediaCommandHandler : IRequestHandler<SubmitAdsMediaCommand, ApiResponse>
    {
        private readonly IAdsMediaService adsMediaService;

        public SubmitAdsMediaCommandHandler(IAdsMediaService _adsMediaService)
        {
            adsMediaService = _adsMediaService;
        }

        public async Task<ApiResponse> Handle(SubmitAdsMediaCommand request, CancellationToken cancellationToken)
        {
            return await adsMediaService.SubmitAdsMedia(request);
        }
    }
}
