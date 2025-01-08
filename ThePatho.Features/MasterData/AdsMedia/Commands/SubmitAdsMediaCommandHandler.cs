using MediatR;
using ThePatho.Features.MasterData.AdsMedia.Service;

namespace ThePatho.Features.MasterData.AdsMedia.Commands
{
    public class SubmitAdsMediaCommandHandler : IRequestHandler<SubmitAdsMediaCommand, string>
    {
        private readonly IAdsMediaService adsMediaService;

        public SubmitAdsMediaCommandHandler(IAdsMediaService _adsMediaService)
        {
            adsMediaService = _adsMediaService;
        }

        public async Task<string> Handle(SubmitAdsMediaCommand request, CancellationToken cancellationToken)
        {
            await adsMediaService.SubmitAdsMedia(request);
            if (request.Action == "ADD")
            {
                return "Ads Category successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Ads Category successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
