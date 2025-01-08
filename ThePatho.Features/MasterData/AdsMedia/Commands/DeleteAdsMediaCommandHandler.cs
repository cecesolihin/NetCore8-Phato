
using MediatR;
using ThePatho.Features.MasterData.AdsMedia.Service;

namespace ThePatho.Features.MasterData.AdsMedia.Commands
{
    public class DeleteAdsMediaCommandHandler : IRequestHandler<DeleteAdsMediaCommand, bool>
    {
        private readonly IAdsMediaService adsMediaService;

        public DeleteAdsMediaCommandHandler(IAdsMediaService _adsMediaService)
        {
            adsMediaService = _adsMediaService;
        }

        public async Task<bool> Handle(DeleteAdsMediaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await adsMediaService.DeleteAdsMedia(request);
                return true;
            }
            catch
            {
                // Log the error here if needed
                return false;
            }
        }
    }

}
