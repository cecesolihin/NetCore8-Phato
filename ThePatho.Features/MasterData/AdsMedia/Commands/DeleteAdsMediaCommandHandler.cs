
using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterData.AdsMedia.Service;

namespace ThePatho.Features.MasterData.AdsMedia.Commands
{
    public class DeleteAdsMediaCommandHandler : IRequestHandler<DeleteAdsMediaCommand, ApiResponse>
    {
        private readonly IAdsMediaService adsMediaService;

        public DeleteAdsMediaCommandHandler(IAdsMediaService _adsMediaService)
        {
            adsMediaService = _adsMediaService;
        }

        public async Task<ApiResponse> Handle(DeleteAdsMediaCommand request, CancellationToken cancellationToken)
        {
            return await adsMediaService.DeleteAdsMedia(request);
        }
    }

}
